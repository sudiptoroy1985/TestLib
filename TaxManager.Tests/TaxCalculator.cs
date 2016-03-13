using System.Collections.Generic;
using System.Linq;
using TaxManager.Tests;

namespace TaxManager.Tests
{
    public interface ITaxCalculator
    {
        OrderBase SetStrategyForOrders(OrderBase order);
    }


    public class TaxCalculator : ITaxCalculator
    {
        public OrderBase SetStrategyForOrders(OrderBase order)
        {
            if (order.OrderItems.Any())
            {
                
            }

            return order;
        }
        
    }
}


