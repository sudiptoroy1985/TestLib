using System;
using System.Collections.Generic;

namespace TaxManager.Tests
{
    public class SalesOrderManagerBase : ISaleOrderManager
    {
        private readonly ITaxCalculator _orderTaxCalculator;

        public SalesOrderManagerBase(ITaxCalculator orderTaxCalculator)
        {
            _orderTaxCalculator = orderTaxCalculator;
        }

        public OrderBase Process(OrderBase order)
        {
            return _orderTaxCalculator.SetStrategyForOrders(order);
        }
    }
}