using System.Linq;
using TestLib.Models;

namespace TestLib
{
    public class SalesOrderManagerBase : ISaleOrderManager
    {
        private readonly ITaxManager _orderTaxManager;

        public SalesOrderManagerBase(ITaxManager orderTaxManager)
        {
            _orderTaxManager = orderTaxManager;
        }

        public OrderBase ProcessOrders(OrderBase order)
        {
            return _orderTaxManager.CalculateTaxForOrders(order);
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