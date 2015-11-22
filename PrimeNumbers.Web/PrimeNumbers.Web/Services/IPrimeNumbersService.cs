using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public interface IPrimeNumbersService
    {
        List<long> GetFirstPrimes(int numberOfPrimes);

        void ResetCache();
    }
}