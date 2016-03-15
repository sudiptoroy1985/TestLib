using System;
using System.Collections.Generic;
using TestLib.Models;

namespace TestLib.TaxStrategy
{
    public class TaxManager : ITaxManager
    {
        private  int _cumulativeTax;

        public void SetTax(int cumulativeTax)
        {
            _cumulativeTax = cumulativeTax;
        }

        public void ApplyTax(ItemBase item)
        {
           var unRoundedAmount = item.Amount * _cumulativeTax / 100 + item.Amount;

            item.Amount = ApplyRounding(unRoundedAmount);
        }

        public decimal ApplyRounding(decimal taxedAmount)
        {
            var w =  Math.Round(taxedAmount * 20 , 1);

            return w/20;
        }
    }
}