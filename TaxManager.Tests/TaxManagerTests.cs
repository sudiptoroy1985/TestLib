using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaxManager.Tests
{
    [TestClass]
    public class TaxManagerTests
    {
        private ISaleOrderManager _saleOrderManager;

        private  ITaxCalculator _taxCalculator;

        [TestInitializeAttribute]
        public void Setup()
        {
            _taxCalculator = new TaxCalculator();

            _saleOrderManager = new SalesOrderManagerBase(_taxCalculator);
        }

        [TestMethod]
        public void NumberOfItemsInOrderRemainsSameAfterTaxProcessing()
        {
            var processedOrders = _saleOrderManager.Process(CreateTestOrder());

           Assert.AreEqual( processedOrders.OrderItems.Count, CreateTestOrder().OrderItems.Count);
        }

        private static OrderBase CreateTestOrder()
        {
            var order = new OrderBase {OrderItems = new List<OrderItem>()};

            order.OrderItems.Add(new OrderItem
            {
                ItemInOrder = new ItemBase()
                {
                    Name = "Book",
                    Amount = (decimal) 23.8,
                },
                Amount = 2
            });

            order.OrderItems.Add(new OrderItem
            {
                ItemInOrder = new ItemBase()
                {
                    Name = "Wine",
                    Amount = (decimal) 12.8,
                },
                Amount = 6
            });
            return order;
        }
    }
}
