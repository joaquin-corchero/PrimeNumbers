using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Models
{
    public class LongCollection
    {
        private int _itemsPerContainer;
        public long CollectionLenght { get; private set; }

        public List<bool[]> Containers = new List<bool[]>();

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
            for (var i = 0; i < numberOfCollections; i++)
            {
                if (itemsLeftToAllocate < _itemsPerContainer)
                    Containers.Add(new bool[itemsLeftToAllocate]);
                else
                    Containers.Add(new bool[this._itemsPerContainer]);

                itemsLeftToAllocate -= this._itemsPerContainer;
            }

            InitializeContainerValues();
        }

        public void InitializeContainerValues()
        {
            Containers.ForEach(c =>
            {
                for (var i = 0; i < c.Length; i++)
                    c[i] = true;
            });
        }

        
    }
}