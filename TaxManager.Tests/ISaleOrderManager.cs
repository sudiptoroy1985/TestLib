using System.Collections.Generic;

namespace TaxManager.Tests
{
    public interface ISaleOrderManager
    {
        OrderBase Process(OrderBase order);

    }
}