using TestLib.Models;

namespace TestLib
{
    public interface ITaxCalculator
    {
        OrderBase SetTaxForOrders(OrderBase order);
    }
}