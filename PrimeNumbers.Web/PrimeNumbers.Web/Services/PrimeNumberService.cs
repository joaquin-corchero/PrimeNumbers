using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public class PrimeNumberService
    {
        public List<long> GetFirstPrimes(long numberOfPrimes)
        {
            List<long> result = new List<long> { 2 };
            var number = 3;
            while (result.Count() < numberOfPrimes)
            {
                var foundDivider = true;
                foreach(var i in result)
                {
                    if (number % i == 0)
                        number++;
                    else
                        foundDivider = false;
                }

                if (!foundDivider)
                    result.Add(number);

                number++;
            }

            return result;
        }
    }
}