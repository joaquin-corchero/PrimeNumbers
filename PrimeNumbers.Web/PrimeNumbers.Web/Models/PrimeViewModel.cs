using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Models
{
    public class PrimeViewModel
    {
        [Required]
        [Range(minimum: 1, maximum:100)]
        [Display(Name = "Number of primes to display")]
        public int? NumberOfPrimesToReturn { get; set; }

        public List<int> Primes { get; private set; }

        public List<List<int>> Rows { get; private set; }

        public PrimeViewModel()
        {
            Primes = new List<int>();
            Rows = new List<List<int>>();
        }

        public PrimeViewModel(int primesToReturn) : this()
        {
            this.NumberOfPrimesToReturn = primesToReturn;
        }

        public override string ToString()
        {
            return NumberOfPrimesToReturn.GetValueOrDefault(0).ToString();
        }

        public void Populate(List<int> primes)
        {
            this.Primes = primes;
            foreach(var prime in primes)
            {
                Rows.Add(new List<int>());
            }
            
        }
    }
}