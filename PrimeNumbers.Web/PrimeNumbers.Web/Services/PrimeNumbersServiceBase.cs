using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Services
{
    public class PrimeNumbersServiceBase
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

        protected int _numberOfPrimesToCalculate;

        protected void ResetCache()
        {
            _primesCache = new List<long>();
        }

        protected int ApproximateNthPrime()
        {
            double n = (double)_numberOfPrimesToCalculate;
            double p;
            if (_numberOfPrimesToCalculate >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (_numberOfPrimesToCalculate >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (_numberOfPrimesToCalculate > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[_numberOfPrimesToCalculate - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }
    }
}