using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public class SieveOfSundaramPrimeService : PrimeNumbersServiceBase, IPrimeNumbersService
    {
        public List<long> GetFirstPrimes(int numberOfPrimes)
        {
            base._numberOfPrimesToCalculate = numberOfPrimes;
            if (_primes.Count >= numberOfPrimes)
                return _primes.Take(numberOfPrimes).ToList();

            int limit = base.ApproximateNthPrime();
            BitArray bits = SieveOfSundaram(limit);
            for (int i = 1, found = 1; 2 * i + 1 <= limit && found < _numberOfPrimesToCalculate; i++)
            {
                if (bits[i])
                {
                    _primes.Add(2 * i + 1);
                    found++;
                }
            }
            return _primes.Take(numberOfPrimes).ToList();
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