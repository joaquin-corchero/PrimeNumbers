using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Controllers;
using PrimeNumbers.Web.Models;
using PrimeNumbers.Web.Services;
using System.Linq;

namespace PrimeNumbers.Web.Tests.Controllers
{
    public abstract class when_working_with_the_home_controller : SpecBase
    {
        protected HomeController _controller;
        protected Mock<IPrimeNumbersService> _primeService = new Mock<IPrimeNumbersService>();
        protected ViewResult _actual;

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
        private PrimeViewModel _outputModel;        

        protected override void Execute()
        {
            _actual = _controller.Index() as ViewResult;
            _outputModel = _actual.Model as PrimeViewModel;
        }

        [TestMethod]
        public void then_an_empty_input_model_is_returned()
        {
            Execute();

            _outputModel.NumberOfPrimesToCalculate.ShouldBeNull();
        }

        [TestMethod]
        public void then_the_correct_view_is_returned()
        {
            Execute();

            _actual.ViewName.ShouldBeEmpty();
        }
    }

    [TestClass]
    public class and_posting_index : when_working_with_the_home_controller
    {
        private PrimeViewModel _viewModel;
        private PrimeViewModel _inputModel = new PrimeViewModel(5, 5);
        private List<long> _serviceOutPut = PrimeHelper.First1000Primes.Take(5).ToList();

        protected override void Establish_context()
        {
            base.Establish_context();
            _primeService.Setup(s => s.GetFirstPrimes(It.IsAny<int>())).Returns(_serviceOutPut);
        }

        protected override void Execute()
        {
            _actual = _controller.Index(_inputModel) as ViewResult;
            _viewModel = (_actual as ViewResult).Model as PrimeViewModel;
        }

        [TestMethod]
        public void then_if_there_are_validation_errors_with_the_input_the_view_is_returned()
        {
            _inputModel = new PrimeViewModel(-1, 5);
            _controller.ModelState.AddModelError("PrimeViewModel", "There is an issue with the data");

            Execute();

            _controller.ModelState.IsValid.ShouldBeFalse();
            _viewModel.Primes.ShouldBeEmpty();
            _actual.ViewName.ShouldBeEmpty();
        }

        [TestMethod]
        public void then_the_primes_get_set_from_the_service()
        {
            Execute();

            _primeService.Verify(s => s.GetFirstPrimes(_inputModel.NumberOfPrimesToCalculate.Value), Times.Once);
            _viewModel.NumberOfPrimesToCalculate.ShouldEqual(_inputModel.NumberOfPrimesToCalculate);
            _viewModel.Primes.ShouldEqual(_serviceOutPut);
        }
    }
}
