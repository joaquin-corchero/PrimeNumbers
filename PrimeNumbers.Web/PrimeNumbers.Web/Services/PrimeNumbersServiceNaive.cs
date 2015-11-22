using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbers.Web.Services
{
    public class PrimeNumbersServiceNaive : PrimeNumbersServiceBase, IPrimeNumbersService
    {
        public override List<long> GeneratePrimes()
        {
            var counter = _primes.LastOrDefault() + 2;
            while (_primes.Count() < base.NumberOfPrimes)
            {
                if (!_primes.Any(p => counter % p == 0))
                    _primes.Add(counter);

                counter = counter + 2;
            }

            return _primes;
        }
    }
}