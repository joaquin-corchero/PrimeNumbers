using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeNumbers.Web.Models.InputModels
{
    public class PrimeInputModel
    {
        private int v1;
        private int v2;

        public PrimeInputModel(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}