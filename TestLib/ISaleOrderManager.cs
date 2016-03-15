using TestLib.Models;

namespace TestLib
{
    public interface ISaleOrderManager
    {
        OrderBase ProcessOrders(OrderBase order);
        void PrintInvoice(OrderBase order);

    }
}