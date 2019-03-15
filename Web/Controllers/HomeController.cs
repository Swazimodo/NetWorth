using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetWorth.Web.Models.Settings;

namespace NetWorth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteConfigurationSettings _siteConfigurationSettings;
        private readonly IHostingEnvironment _environment;

        public HomeController(IOptions<SiteConfigurationSettings> siteConfigurationSettings, IHostingEnvironment environment)
        {
            _siteConfigurationSettings = siteConfigurationSettings.Value;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["EnvironmentName"] = _siteConfigurationSettings.EnvironmentName;
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthorizedSpaFallBack()
        {
            var file = _environment.ContentRootFileProvider.GetFileInfo("ClientApp/build/index.html");
            return PhysicalFile(file.PhysicalPath, "text/html");
        }
    }
}
