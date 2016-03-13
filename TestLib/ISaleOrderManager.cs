using TestLib.Models;

namespace TestLib
{
    public interface ISaleOrderManager
    {
        OrderBase Process(OrderBase order);

        void PrintInvoice(OrderBase order);

    }
}