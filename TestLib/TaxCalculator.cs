using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TestLib.Models;
using TestLib.TaxStrategy;

namespace TestLib
{
    public class TaxCalculator : ITaxCalculator
    {
        public OrderBase SetTaxForOrders(OrderBase order)
        {
            if (order.OrderItems.Any())
            {
                foreach (var orderItem in order.OrderItems)
                {
                    if (!orderItem.ItemInOrder.IsExemptOffAllTaxes)
                    {
                        if (orderItem.ItemInOrder.IsImported)
                        {
                            var applicableTaxPolicy = GetTaxStrategyByOrdertemFactory.SetTaxationPolicy(orderItem.ItemInOrder);

                            applicableTaxPolicy.SetTax(orderItem.ItemInOrder);
                        }
                    }
                }
            }

            return order;
        }
       
    }

}



