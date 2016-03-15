using TestLib.Models;

namespace TestLib
{
    public interface ITaxManager
    {
        void ApplyTax(ItemBase item);
        decimal ApplyRounding(decimal taxedAmount);
        bool IsItemNonExemptFromBasicSalesTax(ItemBase item);
        void SetTax(ItemBase item);
        OrderBase CalculateTaxForOrders(OrderBase order);

    }
}   