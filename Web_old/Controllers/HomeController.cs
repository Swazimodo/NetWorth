using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetWorth.Web.Models.Settings;

namespace NetWorth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteConfigurationSettings _siteConfigurationSettings;

        public HomeController(IOptions<SiteConfigurationSettings> siteConfigurationSettings)
        {
            _siteConfigurationSettings = siteConfigurationSettings.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["EnvironmentName"] = _siteConfigurationSettings.EnvironmentName;
            return View();
        }
    }
}
