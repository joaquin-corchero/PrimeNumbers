using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Services;
using System.Linq;

namespace PrimeNumbers.Web.Tests.Services
{
    public abstract class when_working_with_the_prime_number_service : SpecBase
    {
        protected PrimeNumberService _service = new PrimeNumberService();

        protected abstract void Execute();

    }

    [TestClass]
    public class and_getting_the_n_first_primes : when_working_with_the_prime_number_service
    {
        private List<int> _actual;
        private int _numberOfPrimes = 20;

        protected override void Execute()
        {
            _actual = _service.GetFirstPrimes(_numberOfPrimes);
        }

        [TestMethod]
        public void then_n_number_of_items_are_returned()
        {
            int expected = 5;
            _numberOfPrimes = expected;

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
    }
}
