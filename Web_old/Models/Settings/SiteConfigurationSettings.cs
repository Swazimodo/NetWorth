using System;
namespace NetWorth.Web.Models.Settings
{
    public class SiteConfigurationSettings
    {
        /// <summary>
        /// Specifies the release version
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Title of HS Environment
        /// </summary>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Session timeout value in minutes
        /// </summary>
        public int IdleTimeout { get; set; }

        /// <summary>
        /// Session cookie expriation timespan (dd.hh:mm:ss)
        /// </summary>
        public string SessionExpiration { private get; set; }

        /// <summary>
        /// Date format to be used throughout site
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// creates a settings object with default values
        /// </summary>
        public SiteConfigurationSettings()
        {
            //set default values
            AppVersion = "0.0.1";
            EnvironmentName = "Development"; //Development, Production
            DateFormat = "yyyy-MM-dd";
            IdleTimeout = 24; //time in minutes
            SessionExpiration = "12:00:00"; //dd.hh:mm:ss
        }

        /// <summary>
        /// Gets a timespan from the SessionExpiration string
        /// </summary>
        /// <returns>Default to 24 minutes if SessionExpiration null or invalid</returns>
        public TimeSpan? GetSessionExpirationTimeSpan()
        {
            TimeSpan value;
            if (TimeSpan.TryParse(SessionExpiration, out value))
                return value;
            return null;
        }

        /// <summary>
        /// Check if this is currently in the "Development" environment
        /// </summary>
        public bool IsDevelopment()
        {
            return string.Equals(EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Check if this is currently in the "Production" environment
        /// </summary>
        public bool IsProduction()
        {
            return string.Equals(EnvironmentName, "Production", StringComparison.OrdinalIgnoreCase);
        }
    }
}
