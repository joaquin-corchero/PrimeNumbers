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
using PrimeNumbers.Web.Models.InputModels;
using PrimeNumbers.Web.Models.ViewModels;
using PrimeNumbers.Web.Services;

namespace PrimeNumbers.Web.Tests.Controllers
{
    public abstract class when_working_with_the_home_controller : SpecBase
    {
        protected HomeController _controller;
        protected Mock<IPrimeNumbersService> _primeService = new Mock<IPrimeNumbersService>();
        protected ActionResult _actual;

        protected override void Establish_context()
        {
            base.Establish_context();
            _controller = new HomeController(_primeService.Object);
        }

        protected abstract void Execute();
    }

    [TestClass]
    public class and_getting_the_index : when_working_with_the_home_controller
    {
        private PrimeInputModel _outputModel;        

        protected override void Execute()
        {
            _actual = _controller.Index();
            _outputModel = (_actual as ViewResult).Model as PrimeInputModel;
        }

        [TestMethod]
        public void then_an_empty_input_model_is_returned()
        {
            Execute();

            _outputModel.PrimesToReturn.ShouldBeNull();
        }       
    }

    [TestClass]
    public class and_posting_index : when_working_with_the_home_controller
    {
        private PrimeViewModel _viewModel;
        private PrimeInputModel _inputModel = new PrimeInputModel(5);

        protected override void Execute()
        {
            _actual = _controller.Index(_inputModel);
            _viewModel = (_actual as ViewResult).Model as PrimeViewModel;
        }
    }
}
