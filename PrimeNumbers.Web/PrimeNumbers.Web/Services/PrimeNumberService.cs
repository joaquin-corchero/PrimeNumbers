using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public class PrimeNumberService
    {
        public List<int> GetFirstPrimes(int numberOfPrimes)
        {
            List<int> result = new List<int>();
            while (result.Count() < numberOfPrimes)
                result.Add(numberOfPrimes);

            return result;
        }
    }
}