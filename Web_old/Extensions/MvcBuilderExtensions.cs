using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NetWorth.Web.Models.Settings;

namespace NetWorth.Web.Extensions
{
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Adds the default DateFormatString to the Newtonsoft.Json.JsonSerializerSettings
        /// </summary>
        /// <param name="mvc">Current MVC settings builder</param>
        /// <param name="settings">Settings to configure the SerializerSettings</param>
        /// <returns>The Microsoft.Extensions.DependencyInjection.IMvcBuilder so that additional calls can be chained.</returns>
        public static IMvcBuilder AddSerializerSettings(this IMvcBuilder mvc, SiteConfigurationSettings config)
        {
            mvc.AddJsonOptions(opts =>
            {
                // configure global date serialization format
                opts.SerializerSettings.DateFormatString = config.DateFormat;
                opts.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });
            return mvc;
        }
    }
}
