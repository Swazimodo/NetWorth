using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace NetWorth.Web
{
    public static class AuthHelpers
    {
        public static Task HandleRemoteFailure(RemoteFailureContext context)
        {
            context.HandleResponse();

            if (context.Failure.Message.StartsWith("Correlation failed"))
                context.Response.Redirect("/");
            else
            {
                var description = context.Request.Form["error_description"].ToString();
                if (description.StartsWith("AADB2C90118"))
                    //user requested a password reset
                    context.Response.Redirect("/resetpassword");
                else
                    //dont know what happened but try to get to the app
                    //if you are not authenticated you will get back to B2C
                    context.Response.Redirect("/");
            }

            return Task.CompletedTask;
        }

        public static Task HandleAuthenticationFailed(AuthenticationFailedContext context)
        {
            context.HandleResponse();
            context.Response.Redirect("/Auth");
            return Task.CompletedTask;
        }

        public static Task HandleRemoteSignOut(RemoteSignOutContext context)
        {
            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public static Task HandleRedirectToIdentityProviderForSignOut(RedirectContext context)
        {
            return context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
