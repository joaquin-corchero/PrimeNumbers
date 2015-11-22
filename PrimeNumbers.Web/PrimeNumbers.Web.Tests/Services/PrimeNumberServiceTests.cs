using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Services;
using System.Linq;

namespace PrimeNumbers.Web.Tests.Services
{
    [TestClass]
    public class when_working_with_the_prime_number_service : SpecBase
    {
        protected PrimeNumberService _service = new PrimeNumberService();
    }

    [TestClass]
    public class and_getting_the_n_first_primes : when_working_with_the_prime_number_service
    {
        [TestMethod]
        public void then_n_number_of_items_are_returned()
        {
            int expected = 5;

            List<int> actual = _service.GetFirstPrimes(expected);

            actual.Count().ShouldEqual(expected);
        }

        [TestMethod]
        public void then_numbers_are_ordered_from_smaller_to_greater()
        {
            List<int> actual = _service.GetFirstPrimes(20);

            for(var i =0; i < actual.Count() -1; i++)
            {
                actual[i + 1].ShouldBeGreaterThan(actual[i]);
            }
        }

    }
}
