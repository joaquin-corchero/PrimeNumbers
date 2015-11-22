using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBehave.Spec.MSTest;
using PrimeNumbers.Web.Models;

namespace PrimeNumbers.Web.Tests.Models
{
    public abstract class when_working_with_the_prime_view_model : SpecBase
    {
        protected abstract void Execute();
    }

    [TestClass]
    public class and_populating_the_model : when_working_with_the_prime_view_model
    {
        private List<long> _primes;
        private int _numberOfPrimesToCalculate = 100;
        private int _numberOfPrimesToDisplay = 10;
        private PrimeViewModel _model;

        protected override void Execute()
        {
            _model = new PrimeViewModel(_numberOfPrimesToCalculate, _numberOfPrimesToDisplay);
            _primes = PrimeHelper.First1000Primes.Take(_model.NumberOfPrimesToCalculate.Value).ToList();
            _model.Populate(_primes);
        }

        [TestMethod]
        public void then_the_list_of_primes_gets_populated()
        {
            Execute();

            _model.Primes.ShouldEqual(_primes);
            _model.Primes.Count.ShouldEqual(_model.NumberOfPrimesToCalculate.Value);
        }

        [TestMethod]
        public void then_the_number_of_rows_is_equal_the_the_number_of_primes_to_display()
        {
            Execute();

            _model.Rows.Count().ShouldEqual(_model.NumberOfPrimesToDisplay);
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

        [TestMethod]
        public void then_each_row_contains_number_of_primes_plus_one_items()
        {
            Execute();

            foreach (var row in _model.Rows)
                row.Count.ShouldEqual(_model.PrimesToDisplay.Count + 1);
        }

        [TestMethod]
        public void then_each_member_in_row_is_a_multiple_of_its_row_first_item_and_prime_index()
        {
            Execute();

            for(var i = 0; i < _model.PrimesToDisplay.Count; i ++)
            {
                var row = _model.Rows[i];
                for (var y = 1; y < row.Count; y ++)
                {
                    var expected = _model.Primes[y -1] * row[0];
                    var actual = row[y];
                    actual.ShouldEqual(expected);
                }
            }
        }

    }
}
