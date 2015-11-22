using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeNumbers.Web.Services;

namespace PrimeNumbers.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPrimeNumbersService _primeNumbersService;

        public HomeController(IPrimeNumbersService primeNumbersService)
        {
            this._primeNumbersService = primeNumbersService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}