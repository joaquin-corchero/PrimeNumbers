using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Services;

namespace PrimeNumbers.Web.Tests.Services
{
    [TestClass]
    public abstract class when_working_with_the_prime_number_services : SpecBase
    {
        protected IPrimeNumbersService _service;
        protected List<long> _actual;
        protected int _numberOfPrimesToCalculate = 5;
        protected int _numberOfPrimesToDisplay = 10;

        protected abstract void Execute();

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
            _actual.Any(a => !PrimeHelper.First1000Primes.Contains(a)).ShouldBeFalse();
        }

        [TestMethod]
        public void then_2_of_primes_can_be_returned()
        {
            _numberOfPrimesToCalculate = 2;
            Execute();

            _actual.Count().ShouldEqual(_numberOfPrimesToCalculate);
            CheckActualIsWithin1000List();
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
        public void then_57_of_primes_can_be_returned()
        {
            _numberOfPrimesToCalculate = 57;
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

    [TestClass]
    public class and_getting_the_n_first_primes_with_the_naive_service : when_working_with_the_prime_number_services
    {
        protected override void Establish_context()
        {
            _service = new PrimeNumbersServiceNaive();
        }
        
        protected override void Execute()
        {
            _actual = _service.GetFirstPrimes(_numberOfPrimesToCalculate);
        }
    }

    [TestClass]
    public class and_getting_the_n_first_primes_with_the_sieve_of_eratosthenes_service : when_working_with_the_prime_number_services
    {
        protected override void Establish_context()
        {
            _service = new SieveOfEratosthenesPrimeService();
        }

        protected override void Execute()
        {
            _actual = _service.GetFirstPrimes(_numberOfPrimesToCalculate);
        }

        [TestMethod]
        public void then_big_numbers_of_primes_can_be_returned()
        {
            _numberOfPrimesToCalculate = 20000000;
            Execute();

            _actual.Count().ShouldEqual(_numberOfPrimesToCalculate);
        }
    }

    [TestClass]
    public class and_getting_the_n_first_primes_with_the_sieve_of_sundaram_service : when_working_with_the_prime_number_services
    {
        protected override void Establish_context()
        {
            _service = new SieveOfSundaramPrimeService();
        }

        protected override void Execute()
        {
            _actual = _service.GetFirstPrimes(_numberOfPrimesToCalculate);
        }
    }
}
