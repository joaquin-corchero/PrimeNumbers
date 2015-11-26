using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeNumbers.Web.Models;

namespace PrimeNumbers.Web.Services
{
    public class SieveOfEratosthenesPrimeService : PrimeNumbersServiceBase, IPrimeNumbersService
    {
        private static bool[] _arePrimesCached;

        public static bool[] CachedItems
        {
            get
            {
                if (_arePrimesCached == null)
                {
                    _arePrimesCached = new bool[2];
                    _arePrimesCached[0] = true;
                    _arePrimesCached[1] = true;
                }

                return _arePrimesCached;
            }
            set { _arePrimesCached = value; }
        }

        public override List<long> GeneratePrimes()
        {
            long limit = base.ApproximateNthPrimeLong();

            if(limit > CachedItems.Length)
                ExecuteSieveOfErathosthenes(limit);

            base.ResetCache();
            for (int i = 0, found = 0; i < limit && found < NumberOfPrimes; i++)
            {
                if (!CachedItems[i])
                {
                    _primes.Add(i);
                    found++;
                }
            }
            return _primes.Take(NumberOfPrimes).ToList();
        }

        private void ExecuteSieveOfErathosthenes(long limit)
        {
            var oldSize = CachedItems.Length;
            var cachedItems = CachedItems;

            Array.Resize(ref cachedItems, Convert.ToInt32(limit));

            //weed out the non primes by finding mutiples 
            for (int j = 2; j < limit; j++)
            {
                if (!cachedItems[j])//is true
                {
                    for (long p = 2; (p * j) < limit; p++)
                    {
                        cachedItems[p * j] = true;
                    }
                }
            }

            CachedItems = cachedItems;
        }
    }
}