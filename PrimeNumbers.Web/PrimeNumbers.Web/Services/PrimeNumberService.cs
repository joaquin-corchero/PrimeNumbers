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
            var counter = 0;
            while (result.Count() < numberOfPrimes)
            {
                result.Add(counter);
                counter++;
            }

            return result;
        }
    }
}