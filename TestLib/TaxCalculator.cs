using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using TestLib.Models;


namespace TestLib
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxManager _taxManager;

        public TaxCalculator()
        {
            _taxManager = new TaxManager();   
        }
        public OrderBase CalculateTaxForOrders(OrderBase order)
        {
            if (!order.OrderItems.Any()) return order;

            foreach (var item in order.OrderItems.Select(orderItem => orderItem.ItemInOrder))
            {
                _taxManager.SetTax(SetCompositeApplicableTax(item));

                _taxManager.ApplyTax(item);
            }

            return order;
        }

        public bool IsItemNonExemptFromBasicSalesTax(ItemBase item)
        {
            if (item.ItemType == ItemType.Default)
            {
                return true;
            }

            return false;
        }

        private int SetCompositeApplicableTax(ItemBase item)
        {
            var compositeApplicableTaxList = 0;

            if (IsItemNonExemptFromBasicSalesTax(item))
            {
                compositeApplicableTaxList += 10;
            }

            if (item.IsImported)
            {
                compositeApplicableTaxList += 5;
            }

            return compositeApplicableTaxList;
        }


    }

}



