﻿using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers.Web.Services
{
    public interface IPrimeNumbersService
    {
        List<int> GetFirstPrimes(int numberOfPrimes);
    }

    public class PrimeNumbersService : IPrimeNumbersService
    {
        private static List<int> _primesCache;

        private static List<int> _primes
        {
            get
            {
                if(_primesCache == null)
                    _primesCache = new List<int> { 2, 3 };

                return _primesCache;
            }
        }

        public List<int> GetFirstPrimes(int numberOfPrimes)
        {
            if (_primes.Count >= numberOfPrimes)
                return _primes.Take(numberOfPrimes).ToList();

            var number = _primes.LastOrDefault() + 2;
            while (_primes.Count() < numberOfPrimes)
            {
                if(!_primes.Any(p => number % p == 0))
                    _primes.Add(number);

                number = number + 2;
            }

            return _primes;
        }
    }
}