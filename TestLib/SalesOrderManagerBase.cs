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

        public void PrintInvoice(OrderBase order)
        {
            
        }
    }
}