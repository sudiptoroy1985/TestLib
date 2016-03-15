using TestLib.Models;

namespace TestLib
{
    public interface ITaxCalculator
    {
        OrderBase CalculateTaxForOrders(OrderBase order);
    }
}