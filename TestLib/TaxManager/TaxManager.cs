using System;
using TestLib.Models;

namespace TestLib
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
            item.Amount = ApplyRounding(item.Amount * _cumulativeTax / 100 + item.Amount);
        }

        public decimal ApplyRounding(decimal taxedAmount)
        {
            return Math.Round(taxedAmount * 20, 1)/ 20;
        }
    }
}