using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public interface IPrimeNumbersService
    {
        List<int> GetFirstPrimes(int numberOfPrimes);
    }

    public class PrimeNumbersService : IPrimeNumbersService
    {
        private static List<int> _primes = new List<int> { 2 };

        public List<int> GetFirstPrimes(int numberOfPrimes)
        {
            if (_primes.Count >= numberOfPrimes)
                return _primes.Take(numberOfPrimes).ToList();

            var number = _primes.LastOrDefault() + 1;
            while (_primes.Count() < numberOfPrimes)
            {
                if(! _primes.Any(p => number % p == 0))
                    _primes.Add(number);

                number = number + 2;
            }

            return _primes;
        }
    }
}