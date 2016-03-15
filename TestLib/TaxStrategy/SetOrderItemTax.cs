using System;
using System.Collections.Generic;
using TestLib.Models;

namespace TestLib.TaxStrategy
{
    public class ApplyOrderItemTax : IApplyOrderItemTax
    {
        public void ApplyTax(ItemBase item, List<Action<ItemBase>> taxSetters)
        {
            foreach (var setter in taxSetters)
            {
                setter(item);
            }
            
        }

    }
}