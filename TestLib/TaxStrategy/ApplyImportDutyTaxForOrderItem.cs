using System;
using TestLib.Models;

namespace TestLib.TaxStrategy
{
    public class SetImportDutyTaxForOrderItem : ISetOrderItemTax
    {
        public void SetTax<T>(T item) where T : ItemBase
        {
            item.Amount = (item.Amount * 5 / 100) + item.Amount;
        }
    }
}