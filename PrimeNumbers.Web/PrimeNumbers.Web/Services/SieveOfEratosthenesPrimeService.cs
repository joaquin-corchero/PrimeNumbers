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
        public override List<long> GeneratePrimes()
        {
            long limit = base.ApproximateNthPrimeLong();

            bool[] bits = SiebeOfErathosthenes(limit);

            base.ResetCache();
            for (int i = 0, found = 0; i < limit && found < NumberOfPrimes; i++)
            {
                if (bits[i])
                {
                    _primes.Add(i);
                    found++;
                }
            }
            return _primes.Take(NumberOfPrimes).ToList();
        }

        private bool[] SiebeOfErathosthenes(long limit)
        {
            int numberOfArraysNeeded = Convert.ToInt32(Math.Round(Convert.ToDecimal(limit / int.MaxValue), 0));

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
    }
}