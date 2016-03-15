using TestLib.Models;

namespace TestLib
{
    public interface ITaxManager
    {
        void SetTax(int cumulativeTax);
        void ApplyTax(ItemBase item);
        decimal ApplyRounding(decimal taxedAmount);

    }
}