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
        public OrderBase CalculateTaxForOrders(OrderBase order)
        {
            if (order.OrderItems.Any())
            {
                foreach (var orderItem in order.OrderItems)
                {
                    var item = orderItem.ItemInOrder;

                    var strategy = new ApplyOrderItemTax();

                    var compositeApplicableTaxList = SetCompositeApplicableTax(item);

                    strategy.ApplyTax(item, compositeApplicableTaxList);

                }

                return order;
            }

            return order;
        }

        private List<Action<ItemBase>> SetCompositeApplicableTax(ItemBase item)
        {
            var compositeApplicableTaxList = new List<Action<ItemBase>>();

            if (item.IsImported)
            {
                compositeApplicableTaxList.Add(SetImportTax);
            }

            if (!item.IsExemptedFromSalesTax)
            {
                compositeApplicableTaxList.Add(SetSalesTax);
            }


            return compositeApplicableTaxList;
        }

        public void SetImportTax(ItemBase item)
        {
            item.Amount = ((item.Amount * 5) / 100) + item.Amount;
        }


        public void SetSalesTax(ItemBase item)
        {
            item.Amount = ((item.Amount * 10) / 100) + item.Amount;
        }

    }

}



