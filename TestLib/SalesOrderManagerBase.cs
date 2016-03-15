using System.Linq;
using TestLib.Models;

namespace TestLib
{
    public class SalesOrderManagerBase : ISaleOrderManager
    {
        private readonly ITaxCalculator _orderTaxCalculator;

        public SalesOrderManagerBase(ITaxCalculator orderTaxCalculator)
        {
            _orderTaxCalculator = orderTaxCalculator;
        }

        public OrderBase ProcessOrders(OrderBase order)
        {
            return _orderTaxCalculator.CalculateTaxForOrders(order);
        }

        public string GenerateInvoice(OrderBase order)
        {
            if (order.OrderItems.Any())
            {
                foreach (var ord in order.OrderItems)
                {
                    
                }
            }

            return string.Empty;
        }
    }
}