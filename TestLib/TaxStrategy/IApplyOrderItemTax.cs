using System;
using System.Collections.Generic;
using TestLib.Models;

namespace TestLib.TaxStrategy
{
    public interface ITaxManager
    {
        void SetTax(int cumulativeTax);
        void ApplyTax(ItemBase item);
        decimal ApplyRounding(decimal taxedAmount);

    }
}