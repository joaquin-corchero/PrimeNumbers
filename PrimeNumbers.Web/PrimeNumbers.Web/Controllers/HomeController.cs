using System.Web.Mvc;
using PrimeNumbers.Web.Models;
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
            return View(new PrimeViewModel());
        }

        [HttpPost]
        public ActionResult Index(PrimeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Populate(_primeNumbersService.GetFirstPrimes(model.NumberOfPrimesToCalculate.Value));

            return View(model);
        }
    }
}