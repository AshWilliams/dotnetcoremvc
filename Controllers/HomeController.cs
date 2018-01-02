using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcoremvc.Models;

namespace dotnetcoremvc.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Estamos en Index.";
            await CosmosDB.Initialize();
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
