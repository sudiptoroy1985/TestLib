using System;
using System.Linq;
using TestLib.Models;

namespace TestLib
{
    public class TaxManager : ITaxManager
    {
        private  int _cumulativeTaxForItem;

        public void SetTax(int cumulativeTax)
        {
            _cumulativeTaxForItem = cumulativeTax;
        }

        public void ApplyTax(ItemBase item)
        {
            item.Amount = ApplyRounding(item.Amount * _cumulativeTaxForItem / 100 + item.Amount);
        }

        public decimal ApplyRounding(decimal taxedAmount)
        {
            return Math.Round(taxedAmount * 20, 1)/ 20;
        }

        public bool IsItemNonExemptFromBasicSalesTax(ItemBase item)
        {
            return item.ItemType == ItemType.Default;
        }

        public void SetTax(ItemBase item)
        {
            _cumulativeTaxForItem = 0;

            if (IsItemNonExemptFromBasicSalesTax(item))
            {
                _cumulativeTaxForItem += 10;
            }
            if (item.IsImported)
            {
                _cumulativeTaxForItem += 5;
            }
         }

        public OrderBase CalculateTaxForOrders(OrderBase order)
        {
            if (!order.OrderItems.Any()) return order;

            foreach (var item in order.OrderItems.Select(orderItem => orderItem.ItemInOrder))
            {
               SetTax(item);

               ApplyTax(item);
            }

            return order;
        }
    }
}