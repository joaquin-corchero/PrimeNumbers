using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeNumbers.Web.Models.InputModels;

namespace PrimeNumbers.Web.Models.ViewModels
{
    public class PrimeViewModel : PrimeInputModel
    {
        public List<int> Primes { get; private set; }


        public PrimeViewModel()
        {
            Primes = new List<int>();
        }

        public PrimeViewModel(PrimeInputModel _inputModel)
        {
            base.NumberOfPrimesToReturn = _inputModel.NumberOfPrimesToReturn;
            Primes = new List<int>();
        }

        internal void SetPrimes(List<int> primes)
        {
            this.Primes = primes;
        }
    }
}