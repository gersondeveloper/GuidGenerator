using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuidGenetator.Models;

namespace GuidGenetator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string _insert;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuidViewModel model)
        {
            var response = new GuidGeneratorResponse();
            var guidList = new List<string>();
            if (ModelState.IsValid)
            {
                for (int i = 0; i < model.GuidQuantity; i++)
                {
                    var createGuid = Guid.NewGuid().ToString();
                    if (model.IsUppercase)
                    {
                        createGuid = ConvertToUppercase(createGuid);
                    }

                    if (model.IsBetweenBraces)
                    {
                        createGuid = AddBraces(createGuid);
                    }

                    guidList.Add(createGuid);
                }

                response.GuidList = guidList;
            }

            return View("Created", response);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private string ConvertToUppercase(string myString)
            => myString.ToUpper();

        private string AddBraces(string myString)
            => $"{{{myString}}}";
    }
}