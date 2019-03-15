using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetWorth.Web.Models.Settings;

namespace NetWorth.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly AzureB2CSettings _azureB2CSettings;

        public AuthController(IOptions<AzureB2CSettings> azureB2CSettings)
        {
            _azureB2CSettings = azureB2CSettings.Value;
        }

        [HttpGet("logout")]
        public async Task SignoutAsync()
        {
            // allow either custom or defaut b2c policies
            var authClaim = User.FindFirst("http://schemas.microsoft.com/claims/authnclassreference");
            if (authClaim == null)
                authClaim = User.FindFirst("tfp");

            await HttpContext.SignOutAsync(_azureB2CSettings.SignUpInPolicyName);
        }

        [AllowAnonymous]
        [HttpGet("resetpassword")]
        public async Task ResetPassword()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.ChallengeAsync(_azureB2CSettings.PasswordResetPolicyName, new AuthenticationProperties()
                {
                    RedirectUri = $"/"
                });
            }
        }
    }
}
