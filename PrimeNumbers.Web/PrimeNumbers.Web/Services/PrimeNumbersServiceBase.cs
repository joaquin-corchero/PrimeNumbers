using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public abstract class PrimeNumbersServiceBase
    {
        private static List<long> _primesCache;
        protected static List<long> _primes
        {
            get
            {
                if (_primesCache == null)
                    _primesCache = new List<long> { 2, 3 };

                return _primesCache;
            }
        }

        protected int NumberOfPrimes { get; private set; }

        public void ResetCache()
        {
            _primesCache = new List<long>();
        }

        public List<long> GetFirstPrimes(int numberOfPrimes)
        {
            this.NumberOfPrimes = numberOfPrimes;

            if (_primes.Count >= this.NumberOfPrimes)
                return _primes.Take(this.NumberOfPrimes).ToList();

            return GeneratePrimes();
        }

        public abstract List<long> GeneratePrimes();

       
        protected long ApproximateNthPrimeLong()
        {
            return (long)ApproximsssateNthPrime();
        }

        protected double ApproximsssateNthPrime()
        {
            double n = (double)NumberOfPrimes;
            double p;
            if (NumberOfPrimes >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (NumberOfPrimes >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (NumberOfPrimes > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11, 13 }[NumberOfPrimes];
            }
            else
            {
                p = 0;
            }

            return p;
        }
    }
}