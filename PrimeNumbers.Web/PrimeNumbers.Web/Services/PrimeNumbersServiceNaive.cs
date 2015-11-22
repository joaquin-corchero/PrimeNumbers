using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers.Web.Services
{
    

    public class PrimeNumbersServiceNaive : IPrimeNumbersService
    {
        private static List<long> _primesCache;

        private static List<long> _primes
        {
            get
            {
                if(_primesCache == null)
                    _primesCache = new List<long> { 2, 3 };

                return _primesCache;
            }
        }

        public List<long> GetFirstPrimes(int numberOfPrimes)
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