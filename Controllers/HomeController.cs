using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using dotnetcoremvc.Models;

namespace dotnetcoremvc.Controllers
{
    public class HomeController : Controller
    {

        private static IConfiguration configuration;
        public HomeController(IConfiguration iconfiguration){
            configuration = iconfiguration;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Estamos en Index.";
            await CosmosDB.Initialize(configuration);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Tu descripción de la página.";

            return View();
        }

        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page mvc today.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
