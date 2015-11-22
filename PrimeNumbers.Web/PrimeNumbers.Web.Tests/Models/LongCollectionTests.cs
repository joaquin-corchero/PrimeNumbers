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
        private int _itemsPerContainer = 10;
        private long _collectionLenght = 33;
        private LongCollection _longCollection;

        private void InitializeCollection()
        {
            _longCollection = new LongCollection(_itemsPerContainer, _collectionLenght);
        }

        [TestMethod]
        public void then_the_number_of_collections_created_is_the_number_of_items_per_collection_divided_by_the_total_number_of_items()
        {
            var expected = 4;
            InitializeCollection();

            _longCollection.CollectionContainers.Count.ShouldEqual(expected);
        }

        [TestMethod]
        public void then_the_indexes_for_each_container_gets_set()
        {
            InitializeCollection();

            _longCollection.CollectionContainers[0].StartIndex.ShouldEqual(0);
            _longCollection.CollectionContainers[0].EndIndex.ShouldEqual(9);
            _longCollection.CollectionContainers[1].StartIndex.ShouldEqual(10);
            _longCollection.CollectionContainers[1].EndIndex.ShouldEqual(19);
            _longCollection.CollectionContainers[2].StartIndex.ShouldEqual(20);
            _longCollection.CollectionContainers[2].EndIndex.ShouldEqual(29);
            _longCollection.CollectionContainers[3].StartIndex.ShouldEqual(30);
            _longCollection.CollectionContainers[3].EndIndex.ShouldEqual(32);
        }

        [TestMethod]
        public void then_the_size_of_each_container_gets_set()
        {
            InitializeCollection();

            _longCollection.CollectionContainers[0].BoolCollection.Count.ShouldEqual(10);
            _longCollection.CollectionContainers[1].BoolCollection.Count.ShouldEqual(10);
            _longCollection.CollectionContainers[2].BoolCollection.Count.ShouldEqual(10);
            _longCollection.CollectionContainers[3].BoolCollection.Count.ShouldEqual(3);
        }

        [TestMethod]
        public void then_the_sum_of_the_sizes_adds_up()
        {
            InitializeCollection();
            var totalLength= _longCollection.CollectionContainers[0].BoolCollection.Count + 
            _longCollection.CollectionContainers[1].BoolCollection.Count +
            _longCollection.CollectionContainers[2].BoolCollection.Count +
            _longCollection.CollectionContainers[3].BoolCollection.Count;

            totalLength.ShouldEqual(Convert.ToInt32(this._collectionLenght));
        }

        [TestMethod]
        public void then_by_default_all_the_values_but_0_and_1_are_set_to_true()
        {
            InitializeCollection();
            for(var i = 0; i < _longCollection.CollectionContainers.Count; i ++)
            {
                for(var y =0; i < _longCollection.CollectionContainers[i].BoolCollection.Count; i ++)
                {
                    if(i ==0 && y== 0 || y ==1)
                        _longCollection.CollectionContainers[i].BoolCollection[y].ShouldBeFalse();
                    else
                        _longCollection.CollectionContainers[i].BoolCollection[y].ShouldBeTrue();
                }
            }
        }

        [TestMethod]
        public void then_one_item_on_the_first_container_can_be_set()
        {
            int indexToSet = 5;
            InitializeCollection();

            _longCollection.SetToFalse(indexToSet);

            for (var i = 0; i < _longCollection.CollectionContainers[0].BoolCollection.Count; i++)
            {
                var value = _longCollection.CollectionContainers[0].BoolCollection[i];
                if (i == indexToSet || i == 0 || i == 1)
                    value.ShouldBeFalse();
                else
                    value.ShouldBeTrue();
            }
            _longCollection.CollectionContainers[1].BoolCollection.ForEach(i => i.ShouldEqual(true));
            _longCollection.CollectionContainers[2].BoolCollection.ForEach(i => i.ShouldEqual(true));
            _longCollection.CollectionContainers[3].BoolCollection.ForEach(i => i.ShouldEqual(true));
        }

        [TestMethod]
        public void then_one_item_on_the_second_container_can_be_set()
        {
            int indexToSet = 22;
            InitializeCollection();

            _longCollection.SetToFalse(indexToSet);

            for (var i = 0; i < _longCollection.CollectionContainers[2].BoolCollection.Count; i++)
            {
                var value = _longCollection.CollectionContainers[2].BoolCollection[i];
                if (i == Convert.ToInt32(indexToSet % this._itemsPerContainer))
                    value.ShouldBeFalse();
                else
                    value.ShouldBeTrue();
            }
            
            _longCollection.CollectionContainers[1].BoolCollection.ForEach(i => i.ShouldEqual(true));
            _longCollection.CollectionContainers[3].BoolCollection.ForEach(i => i.ShouldEqual(true));
        }

        [TestMethod]
        public void then_one_item_on_the_last_position_can_be_set()
        {
            int indexToSet = Convert.ToInt32(_collectionLenght) -1;
            InitializeCollection();

            _longCollection.SetToFalse(indexToSet);

            for (var i = 0; i < _longCollection.CollectionContainers[3].BoolCollection.Count; i++)
            {
                var value = _longCollection.CollectionContainers[3].BoolCollection[i];
                if (i == Convert.ToInt32(indexToSet % this._itemsPerContainer))
                    value.ShouldBeFalse();
                else
                    value.ShouldBeTrue();
            }
            
            _longCollection.CollectionContainers[1].BoolCollection.ForEach(i => i.ShouldEqual(true));
            _longCollection.CollectionContainers[2].BoolCollection.ForEach(i => i.ShouldEqual(true));
        }

        [TestMethod]
        public void then_the_value_of_an_item_can_be_found()
        {
            int indexToGet = 5;
            InitializeCollection();

            _longCollection.CollectionContainers[0].BoolCollection[5] = false;

            var actual = _longCollection.Get(indexToGet);
            actual.ShouldBeFalse();
        }
    }
}
