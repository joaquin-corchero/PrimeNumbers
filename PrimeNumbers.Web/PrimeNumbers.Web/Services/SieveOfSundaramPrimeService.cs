using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public class SieveOfSundaramPrimeService : PrimeNumbersServiceBase, IPrimeNumbersService
    {
        public override List<long> GeneratePrimes()
        {
            int limit = base.ApproximateNthPrime();
            BitArray bits = SieveOfSundaram(limit);
            for (int i = 1, found = 1; 2 * i + 1 <= limit && found < NumberOfPrimes; i++)
            {
                if (bits[i])
                {
                    _primes.Add(2 * i + 1);
                    found++;
                }
            }
            return _primes.Take(NumberOfPrimes).ToList();
        }

        private BitArray SieveOfSundaram(int limit)
        {
            limit /= 2;
            BitArray bits = new BitArray(limit + 1, true);
            for (int i = 1; 3 * i + 1 < limit; i++)
            {
                for (int j = 1; i + j + 2 * i * j <= limit; j++)
                {
                    bits[i + j + 2 * i * j] = false;
                }
            }
            return bits;
        }
    }
}