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
    [TestClass]
    public class when_working_with_the_long_collection : SpecBase
    {
        private int _itemsPerContainer = 20;
        private long _collectionLenght = 100;
        private LongCollection _longColection;

        private void Execute()
        {
            _longColection = new LongCollection(_itemsPerContainer, _collectionLenght);
        }

        [TestMethod]
        public void then_the_number_of_collections_created_is_the_number_of_items_per_collection_divided_by_the_total_number_of_items()
        {
            _collectionLenght = 33;
            _itemsPerContainer = 10;
            var expected = 4;
            Execute();

            _longColection.Containers.Count.ShouldEqual(expected);
        }

        [TestMethod]
        public void then_the_size_of_each_container_gets_set()
        {
            _collectionLenght = 33;
            _itemsPerContainer = 10;
            var expected = 4;
            Execute();

            _longColection.Containers[0].Length.ShouldEqual(10);
            _longColection.Containers[1].Length.ShouldEqual(10);
            _longColection.Containers[2].Length.ShouldEqual(10);
            _longColection.Containers[3].Length.ShouldEqual(3);
        }
    }
}
