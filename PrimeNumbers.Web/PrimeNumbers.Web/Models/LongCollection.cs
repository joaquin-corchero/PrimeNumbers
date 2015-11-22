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

        private List<long[]> Containers = new List<long[]>();

        public LongCollection(int itemsPerContainer, long collectionLenght)
        {
            this._itemsPerContainer = itemsPerContainer;
            this.CollectionLenght = collectionLenght;
        }
    }
}