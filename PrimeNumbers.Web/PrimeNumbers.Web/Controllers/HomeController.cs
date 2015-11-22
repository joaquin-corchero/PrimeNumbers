using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeNumbers.Web.Models.InputModels;
using PrimeNumbers.Web.Models.ViewModels;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View(new PrimeInputModel());
        }

        [HttpPost]
        public ActionResult Index(PrimeInputModel _inputModel)
        {
            PrimeViewModel model = new PrimeViewModel(_inputModel);

            if (!ModelState.IsValid)
                return View(model);

            model.SetPrimes(_primeNumbersService.GetFirstPrimes(model.NumberOfPrimesToReturn.Value));

            return View(model);
        }
    }
}