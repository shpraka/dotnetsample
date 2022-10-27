using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using netc31.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace netc31.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string runtimePath = System.IO.Path.GetDirectoryName(typeof(object).Assembly.Location);
            // Making the assumption that the path looks like this
            // C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.0.6
            string version = runtimePath.Substring(runtimePath.LastIndexOf('\\') + 1);
            var view = View();
            view.ViewData.Add("version", version);
            return view;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
