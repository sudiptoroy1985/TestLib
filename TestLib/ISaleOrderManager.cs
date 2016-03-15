using TestLib.Models;

namespace TestLib
{
    public interface ISaleOrderManager
    {
        OrderBase ProcessOrders(OrderBase order);
        string GenerateInvoice(OrderBase order);

    }
}