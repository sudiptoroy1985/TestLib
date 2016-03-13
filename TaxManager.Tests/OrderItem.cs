using System.Collections.Generic;

namespace TaxManager.Tests
{
    public class OrderItem
    {
        public int Amount { get; set; }
        public ItemBase ItemInOrder { get; set; }

    }


    public class OrderBase
    {
        public List<OrderItem> OrderItems { get; set; }
    }
}