using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NetWorth.Web.Extensions;
using NetWorth.Web.Models.Settings;

namespace NetWorth.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            //services.Configure<AzureB2CSettings>(options => Configuration.GetSection("AzureB2CSettings").Bind(options));
            //var b2cSettings = Configuration.GetSection("AzureB2CSettings").Get<AzureB2CSettings>();

            //services.AddMvc(config =>
            //{
            //    //var policy = new AuthorizationPolicyBuilder()
            //    //    .RequireAuthenticatedUser()
            //    //    .Build();

            //    //config.Filters.Add(new AuthorizeFilter(policy));
            //})
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //// In production, the React files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});

            ////services.AddAuthentication(options =>
            ////{
            ////    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            ////    options.DefaultChallengeScheme = b2cSettings.SignUpInPolicyName;
            ////})
            ////    .AddOpenIdConnect(b2cSettings.SignUpInPolicyName, options => SetOptionsForOpenIdConnectPolicy(b2cSettings.SignUpInPolicyName, b2cSettings, options))
            ////    .AddOpenIdConnect(b2cSettings.PasswordResetPolicyName, options => SetOptionsForOpenIdConnectPolicy(b2cSettings.PasswordResetPolicyName, b2cSettings, options))
            ////    .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});

            // here you can see we make sure it doesn't start with /api, if it does, it'll 404 within .NET if it can't be found
            app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api") && !x.Request.Path.Value.StartsWith("/ClientApp")
                && !x.Request.Path.Value.StartsWith("/build") && !x.Request.Path.Value.StartsWith("/static"), builder =>
                {
                    builder.UseMvc(routes =>
                    {
                        routes.MapSpaFallbackRoute(
                            name: "spa-fallback",
                            defaults: new { controller = "Home", action = "AuthorizedSpaFallBack" });
                    });
                });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });



            ////app.ConfigureSecurityHeaders();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseStaticFiles("/ClientApp/build/**");
            ////app.UseAuthentication();
            //app.UseHttpsRedirection();
            ////app.UseSpaStaticFiles(new StaticFileOptions() {
            ////    RequestPath="/ClientApp/build/**"
            ////});

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}");
            //});

            ////app.UseSpa(spa =>
            ////{
            ////    spa.Options.SourcePath = "ClientApp";

            ////    if (env.IsDevelopment())
            ////    {
            ////        spa.UseReactDevelopmentServer(npmScript: "start");
            ////    }
            ////});

            //// here you can see we make sure it doesn't start with /api, if it does, it'll 404 within .NET if it can't be found
            //app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api") && !x.Request.Path.Value.StartsWith("/ClientApp")
            //    && !x.Request.Path.Value.StartsWith("/build") && !x.Request.Path.Value.StartsWith("/static"), builder =>
            //{
            //    builder.UseMvc(routes =>
            //    {
            //        routes.MapSpaFallbackRoute(
            //            name: "spa-fallback",
            //            defaults: new { controller = "Home", action = "AuthorizedSpaFallBack" });
            //    });
            //});

            ////app.UseMvc(routes =>
            ////{
            ////    routes.MapRoute(
            ////        name: "default",
            ////        template: "{controller=Home}/{action=AuthorizedSpaFallBack}");
            ////});

            ////// here you can see we make sure it doesn't start with /api, if it does, it'll 404 within .NET if it can't be found
            ////app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api"), builder =>
            ////{
            ////    builder.UseMvc(routes =>
            ////    {
            ////        routes.MapSpaFallbackRoute(
            ////            name: "spa-fallback",
            ////            defaults: new { controller = "Home", action = "AuthorizedSpaFallBack" });
            ////    });
            ////});

            ////// here you can see we make sure it doesn't start with /api, if it does, it'll 404 within .NET if it can't be found
            ////app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api"), builder =>
            ////{
            ////    builder.UseMvc(routes =>
            ////    {
            ////        routes.MapSpaFallbackRoute(
            ////            name: "spa-fallback",
            ////            defaults: new { controller = "Home", action = "AuthorizedSpaFallBack" });
            ////    });
            ////});

            ////app.UseSpa(spa =>
            ////{
            ////    spa.Options.SourcePath = "ClientApp/build";

            ////    if (env.IsDevelopment())
            ////    {
            ////        spa.UseReactDevelopmentServer(npmScript: "start");
            ////    }
            ////});
        }

        private void SetOptionsForOpenIdConnectPolicy(string policyName, AzureB2CSettings b2cSettings, OpenIdConnectOptions options)
        {
            options.MetadataAddress = $"https://login.microsoftonline.com/{b2cSettings.Tenant}/v2.0/.well-known/openid-configuration?p={policyName}";
            options.ClientId = b2cSettings.ClientId;
            options.ResponseType = OpenIdConnectResponseType.IdToken;
            options.CallbackPath = $"/signin/{policyName}";
            options.SignedOutCallbackPath = $"/signout/{policyName}";
            options.SignedOutRedirectUri = "/";
            options.TokenValidationParameters.NameClaimType = "name";

            options.Events = new OpenIdConnectEvents
            {
                OnRemoteFailure = AuthHelpers.HandleRemoteFailure,
                OnAuthenticationFailed = AuthHelpers.HandleAuthenticationFailed,
                OnRemoteSignOut = AuthHelpers.HandleRemoteSignOut,
                OnRedirectToIdentityProviderForSignOut = AuthHelpers.HandleRedirectToIdentityProviderForSignOut
            };
        }
    }
}
