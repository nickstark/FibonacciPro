using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Numerics;
using FibonacciCalculator;

namespace FibonacciPro.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Calculator calc = new Calculator();
            var results = calc.Compute(50).GetAllResults();
            return View(results);
        }

        public ActionResult Calculate(int? num)
        {
            if (num == null)
            {
                // call invalid input view
                return View("NoResults");
            }

            int calculateSize = num.GetValueOrDefault();

            if (calculateSize < 0)
            {
                calculateSize = -1 * calculateSize;
            }

            Calculator calc = new Calculator();
            var results = calc.Compute(calculateSize).GetAllResults();
            return View(results);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}