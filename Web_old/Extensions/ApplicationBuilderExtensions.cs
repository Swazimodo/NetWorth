using Microsoft.AspNetCore.Builder;

namespace NetWorth.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns>Returns a IApplicationBuilder for app config chaining</returns>
        public static IApplicationBuilder ConfigureSecurityHeaders(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                // Do not allow the pages to be framed, to prevent clickjacking attacks. See https://dotnetcoretutorials.com/2017/01/08/set-x-frame-options-asp-net-core
                context.Response.Headers.Add("X-Frame-Options", "sameorigin");

                // Set X-XSS-Protection. See https://dotnetcoretutorials.com/2017/01/10/set-x-xss-protection-asp-net-core
                context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");

                // Set X-Content-Type-Options. See (https://dotnetcoretutorials.com/2017/01/20/set-x-content-type-options-asp-net-core
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

                await next();
            });
        }
    }
}
