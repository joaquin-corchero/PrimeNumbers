using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public class SieveOfEratosthenesPrimeService : PrimeNumbersServiceBase, IPrimeNumbersService
    {
        public List<long> GetFirstPrimes(int numberOfPrimes)
        {
            base._numberOfPrimesToCalculate = numberOfPrimes + 1;
            if (_primes.Count >= numberOfPrimes)
                return _primes.Take(numberOfPrimes).ToList();

            int limit = base.ApproximateNthPrime();
            base.ResetCache();
            BitArray bits = SieveOfEratosthenes(limit);
            for (int i = 0, found = 0; i < limit && found < _numberOfPrimesToCalculate; i++)
            {
                if (bits[i])
                {
                    _primes.Add(i);
                    found++;
                }
            }
            return _primes;
        }        

        private BitArray SieveOfEratosthenes(int limit)
        {
            BitArray bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }
    }
}