using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NCKU_History.Models;
using NCKU_Model.DBModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NCKU_History.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NCKUContext _nCKUContext;

        public HomeController(ILogger<HomeController> logger, NCKUContext nCKUContext)
        {
            _logger = logger;
            _nCKUContext = nCKUContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
            var res = _nCKUContext.Categories.Where(x => true);
            return Ok(res);
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
