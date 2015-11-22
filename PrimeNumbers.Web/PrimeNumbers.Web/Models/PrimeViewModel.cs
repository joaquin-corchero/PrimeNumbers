using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PrimeNumbers.Web.Models
{
    public class PrimeViewModel
    {
        private const int NUMBER_OF_PRIMES_TO_DISPLAY = 10;
        [Required]
        [Range(minimum: 1, maximum: 2000000)]
        [Display(Name = "Number of primes to calculate")]
        public int? NumberOfPrimesToCalculate { get; set; }

        [Range(minimum: 1, maximum: 10)]
        public int NumberOfPrimesToDisplay { get; set; }

        public List<long> Primes { get; private set; }

        public List<long> PrimesToDisplay { get { return this.Primes.Take(NumberOfPrimesToDisplay).ToList(); } }

        public List<List<long>> Rows { get; private set; }

        public PrimeViewModel()
        {
            Primes = new List<long>();
            Rows = new List<List<long>>();
            NumberOfPrimesToDisplay = NUMBER_OF_PRIMES_TO_DISPLAY;
        }

        public PrimeViewModel(int primesToCalculate, int primesToDisplay) : this()
        {
            this.NumberOfPrimesToCalculate = primesToCalculate;
            this.NumberOfPrimesToDisplay = primesToDisplay;
        }

        public void Populate(List<long> primes)
        {
            this.Primes = primes;
            this.PopulateRows();
        }

        private void PopulateRows()
        {
            this.PrimesToDisplay.ForEach(p => this.PopulateRow(p));
        }

        private void PopulateRow(long prime)
        {
            var firstItem = prime;
            var row = new List<long> { firstItem };

            this.PrimesToDisplay.ForEach(p => row.Add(p * firstItem));

            this.Rows.Add(row);
        }
    }
}