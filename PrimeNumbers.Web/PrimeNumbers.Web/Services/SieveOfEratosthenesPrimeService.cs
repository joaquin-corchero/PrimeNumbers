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
            base._numberOfPrimesToCalculate = numberOfPrimes;
            if (_primes.Count >= numberOfPrimes)
                return _primes.Take(numberOfPrimes).ToList();

            long limit = base.ApproximateNthPrimeLong();
            //BitArray bits = SieveOfEratosthenes(limit);
            bool[] bits = SiebeOfErathosthenes(limit);
            base.ResetCache();
            for (int i = 0, found = 0; i < limit && found < _numberOfPrimesToCalculate; i++)
            {
                if (bits[i])
                {
                    _primes.Add(i);
                    found++;
                }
            }
            return _primes.Take(numberOfPrimes).ToList();
        }

        private bool[] SiebeOfErathosthenes(long limit)
        {
            bool[] result = new bool[limit];//by default they're all false
            for (int i = 2; i < limit; i++)
            {
                result[i] = true;//set all numbers to true
            }
            //weed out the non primes by finding mutiples 
            for (int j = 2; j < limit; j++)
            {
                if (result[j])//is true
                {
                    for (long p = 2; (p * j) < limit; p++)
                    {
                        result[p * j] = false;
                    }
                }
            }

            return result;
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