using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Models
{
    public class CollectionContainer
    {
        public long StartIndex { get; private set; }
        public long EndIndex { get; private set; }

        public List<bool> BoolCollection { get; private set; }

        public CollectionContainer(long startIndex, long endIndex)
        {
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;

            int size = Convert.ToInt32(this.EndIndex - this.StartIndex) + 1;

            this.BoolCollection = new List<bool>(size);
            for (var i = 0; i < size; i++)
                BoolCollection.Add(true);
        }
    }
    public class LongCollection
    {
        private int _itemsPerContainer;
        public long CollectionLenght { get; private set; }

        public List<CollectionContainer> CollectionContainers = new List<CollectionContainer>();

        public LongCollection(int itemsPerContainer, long collectionLenght)
        {
            this._itemsPerContainer = itemsPerContainer;
            this.CollectionLenght = collectionLenght;

            InitializeContainers();
        }

        private void InitializeContainers()
        {
            int numberOfCollections = Convert.ToInt32(this.CollectionLenght / this._itemsPerContainer);
            if (this.CollectionLenght % this._itemsPerContainer > 0)
                numberOfCollections++;

            var itemsLeftToAllocate = CollectionLenght;
            long startIndex = 0;
            for (var i = 0; i < numberOfCollections; i++)
            {
                if (itemsLeftToAllocate < _itemsPerContainer)
                {
                    CollectionContainers.Add(new CollectionContainer(startIndex, this.CollectionLenght -1));
                }
                else
                {
                    CollectionContainers.Add(new CollectionContainer(startIndex, ((this.CollectionContainers.Count +1) *_itemsPerContainer) - 1));
                }
                startIndex += _itemsPerContainer;
                itemsLeftToAllocate -= this._itemsPerContainer;
            }
        }

        public void SetToFalse(int index)
        {
            var collection = this.CollectionContainers.FirstOrDefault(c => c.StartIndex <= index && c.EndIndex >= index);

            var indexToSet = index % this._itemsPerContainer;
            collection.BoolCollection[indexToSet] = false;
        }
    }
}