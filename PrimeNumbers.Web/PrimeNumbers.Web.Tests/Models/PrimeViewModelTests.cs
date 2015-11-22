using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Models;

namespace PrimeNumbers.Web.Tests.Models
{
    public class when_working_with_the_prime_view_model : SpecBase
    {
    }

    [TestClass]
    public class and_populating_the_model : when_working_with_the_prime_view_model
    {
        private List<int> _primes = new List<int> { 2, 3, 5 };
        private PrimeViewModel _model = new PrimeViewModel(3);

        private void Execute()
        {
            _model.Populate(_primes);
        }

        [TestMethod]
        public void then_the_list_of_primes_gets_populated()
        {
            Execute();

            _model.Primes.ShouldEqual(_primes);
        }

        [TestMethod]
        public void then_the_rows_number_is_equal_to_the_number_of_primes()
        {
            Execute();

            _model.Rows.Count().ShouldEqual(_primes.Count);
        }

        [TestMethod]
        public void then_the_first_item_on_each_row_is_the_prime_with_the_index()
        {
            Execute();

            for (var i = 0; i < _model.Rows.Count; i++)
            {
                var row = _model.Rows[i];
                row[0].ShouldEqual(_model.Primes[i]);
            }
        }

    }
}
