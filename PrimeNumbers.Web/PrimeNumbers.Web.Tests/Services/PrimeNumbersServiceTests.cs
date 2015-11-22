using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Services;

namespace PrimeNumbers.Web.Tests.Services
{
    public abstract class when_working_with_the_prime_number_service : SpecBase
    {
        protected PrimeNumbersServiceNaive _service;

        protected abstract void Execute();

        protected override void Establish_context()
        {
            _service = new PrimeNumbersServiceNaive();
        }

    }

    [TestClass]
    public class and_getting_the_n_first_primes : when_working_with_the_prime_number_service
    {
        private List<long> _actual;
        private int _numberOfPrimesToCalculate = 5;
        private int _numberOfPrimesToDisplay = 10;
        //list taken from https://primes.utm.edu/lists/small/1000.txt

        protected override void Execute()
        {
            _actual = _service.GetFirstPrimes(_numberOfPrimesToCalculate);
        }

        [TestMethod]
        public void then_n_number_of_items_are_returned()
        {
            int expected = 5;
            _numberOfPrimesToCalculate = expected;

            Execute();

            _actual.Count().ShouldEqual(expected);
        }

        [TestMethod]
        public void then_numbers_are_ordered_from_smaller_to_greater()
        {
            Execute();

            for (var i = 0; i < _actual.Count() - 1; i++)
                _actual[i + 1].ShouldBeGreaterThan(_actual[i]);
        }

        [TestMethod]
        public void then_the_numbers_returned_are_prime()
        {
            Execute();

            CheckActualIsWithin1000List();
        }

        private void CheckActualIsWithin1000List()
        {
            _actual.Any(a=> !PrimeHelper.First1000Primes.Contains(a)).ShouldBeFalse();
        }

        [TestMethod]
        public void then_100_of_primes_can_be_returned()
        {
            _numberOfPrimesToCalculate = 100;
            Execute();

            _actual.Count().ShouldEqual(_numberOfPrimesToCalculate);
            CheckActualIsWithin1000List();
        }

        [TestMethod]
        public void then_1000_of_primes_can_be_returned()
        {
            _numberOfPrimesToCalculate = 1000;
            Execute();

            _actual.Count().ShouldEqual(_numberOfPrimesToCalculate);
            CheckActualIsWithin1000List();
        }

        [TestMethod]
        public void then_10000_of_primes_can_be_returned()
        {
            _numberOfPrimesToCalculate = 10000;
            Execute();

            _actual.Count().ShouldEqual(_numberOfPrimesToCalculate);
            PrimeHelper.First1000Primes.ForEach(i => _actual.Contains(i).ShouldBeTrue());
        }
    }
}
