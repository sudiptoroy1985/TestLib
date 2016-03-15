namespace TestLib.Models
{
    public class ItemBase
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsImported { get; set; }
        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Default = 0,
        Books,
        Food,
        Medicalproducts
        
    }




}
