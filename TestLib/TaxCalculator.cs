using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using TestLib.Models;
using TestLib.TaxStrategy;

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

        private static int SetCompositeApplicableTax(ItemBase item)
        {
            var compositeApplicableTaxList = 0;

            if (!item.IsExemptedFromSalesTax)
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



