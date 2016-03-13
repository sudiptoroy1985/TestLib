using TestLib.Models;

namespace TestLib.TaxStrategy
{
    public static class GetTaxStrategyByOrdertemFactory
    {
        public static ISetOrderItemTax SetTaxationPolicy(ItemBase item)
        {
            if (item.IsImported)
            {
                return new SetImportDutyTaxForOrderItem();
            }

            return new SetImportDutyTaxForOrderItem();

        }

    }
}