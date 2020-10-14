using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabPractice2_FizzBuzz.Models;

namespace LabPractice2_FizzBuzz.Controllers
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

        [HttpGet]
        public IActionResult FizzBuzz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FizzBuzz(int multipleInput1, int multipleInput2, int rangeInput1, int rangeInput2)
        {

            var model = new FizzBuzzModel()
            { 
                
                FizzNum = multipleInput1,
                BuzzNum = multipleInput2,
                RangeStart = rangeInput1,
                RangeEnd = rangeInput2

            }; 

            for (var i = rangeInput1; i <= rangeInput2; i++)
            {
                if (i % multipleInput1 == 0 && i % multipleInput2 == 0)
                {
                    model.Output += "FizzBuzz ";
                }
                else if (i % multipleInput1 == 0)
                {
                    model.Output += "Fizz ";
                }
                else if (i % multipleInput2 == 0)
                {
                    model.Output += "Buzz ";
                }
                else
                {
                    model.Output += (i + " ");
                }
            }

            return View(nameof(Result), model);

        }

        public IActionResult Result()
        {

            var model = new FizzBuzzModel();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
