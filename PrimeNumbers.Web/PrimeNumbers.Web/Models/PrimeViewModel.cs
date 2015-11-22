using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PrimeNumbers.Web.Models
{
    public class PrimeViewModel
    {
        [Required]
        [Range(minimum: 1, maximum:int.MaxValue)]
        [Display(Name = "Number of primes to calculate")]
        public int? NumberOfPrimesToCalculate { get; set; }

        [Range(minimum: 1, maximum: 10)]
        public int NumberOfPrimesToDisplay { get; set; }

        public List<long> Primes { get; private set; }

        public List<long> PrimesToDisplay
        {
            get { return this.Primes.Take(NumberOfPrimesToDisplay).ToList(); }
        }

        public List<List<long>> Rows { get; private set; }

        public PrimeViewModel()
        {
            Primes = new List<long>();
            Rows = new List<List<long>>();
        }

        public PrimeViewModel(int primesToCalculate, int primesToDisplay) : this()
        {
            this.NumberOfPrimesToCalculate = primesToCalculate;
            this.NumberOfPrimesToDisplay = primesToDisplay;
        }

        public void Populate(List<long> primes)
        {
            if (this.NumberOfPrimesToDisplay < this.NumberOfPrimesToCalculate)
                this.NumberOfPrimesToDisplay = this.NumberOfPrimesToCalculate.Value;

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

            this.Primes.ForEach(p => row.Add(p * firstItem));

            this.Rows.Add(row);
        }
    }
}