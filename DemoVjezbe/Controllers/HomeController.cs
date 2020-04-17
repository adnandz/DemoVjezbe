using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoVjezbe.Models;

namespace DemoVjezbe.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Ime = "Abc";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Primjer()
        {
            ViewBag.PrviPodatak = "Ovo je prvi podatak";
            string tekst = "Ovo je drugi podatak";
            List<string> lista = new List<string>();
            for(int i = 0; i<10; i++)
            {
                lista.Add(tekst + " " + i.ToString());
            }
            return View(lista);
        }
    }
}
