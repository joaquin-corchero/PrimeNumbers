using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Models.InputModels
{
    public class PrimeInputModel
    {
        [Required]
        [Range(minimum: 1, maximum:100)]
        [Display(Description = "Number of primes to display")]
        public int? NumberOfPrimesToReturn { get; set; }

        public PrimeInputModel(){}

        public PrimeInputModel(int primesToReturn)
        {
            this.NumberOfPrimesToReturn = primesToReturn;
        }
    }
}