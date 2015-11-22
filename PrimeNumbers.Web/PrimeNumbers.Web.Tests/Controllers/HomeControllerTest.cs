using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web;
using PrimeNumbers.Web.Controllers;
using PrimeNumbers.Web.Services;

namespace PrimeNumbers.Web.Tests.Controllers
{
    [TestClass]
    public class when_working_with_the_home_controller : SpecBase
    {
        protected HomeController _controller;
        protected Mock<IPrimeNumbersService> _primeService = new Mock<IPrimeNumbersService>();

        protected override void Establish_context()
        {
            base.Establish_context();
            _controller = new HomeController(_primeService.Object);
        }
    }
}
