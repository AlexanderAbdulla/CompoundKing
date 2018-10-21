using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CoumpoundInterest
    {
        public CoumpoundInterest(double interestRate, double principal, double timesPerYear, double years)
        {
            this.interestRate = interestRate /100;
            this.principal = principal;
            this.timesPerYear = timesPerYear;
            this.years = years;
        }

        public double CalculateCompoundnInterest()
        {

            double body = 1 + (interestRate / timesPerYear);
            double exponent = timesPerYear * years;
            return principal * Math.Round(Math.Pow(body, exponent), 2);
        }

        public double interestRate { get; set; }
        public double timesPerYear { get; set; }
        public double years { get; set; }
        public double principal { get; set;  }

    }
}
