namespace TestLib.Models
{
    public class ItemBase
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsImported { get; set; }
        public bool IsExemptedFromSalesTax { get; set; }
    }
    


}
