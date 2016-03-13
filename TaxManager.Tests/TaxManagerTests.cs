using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;
using TestLib.Models;

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


        [TestMethod]
        public void AmountOfItemsUnchangedAfterTaxProcessingIfExempted()
        {
            var processedOrders = _saleOrderManager.Process(CreateTestOrder());

            Assert.AreEqual(processedOrders.OrderItems.Count, CreateTestOrder().OrderItems.Count);
        }

        [TestMethod]
        public void OneImportedItemCorrectTaxApplied()
        {
            var processedOrders = _saleOrderManager.Process(CreateOrderWithOneImportedItem());

            Assert.IsTrue(processedOrders.OrderItems[0].ItemInOrder.Amount == (decimal) 24.99);
        }

        private OrderBase CreateOrderWithOneImportedItem()
        {
            var order = new OrderBase { OrderItems = new List<OrderItem>() };

            order.OrderItems.Add(new OrderItem
            {
                ItemInOrder = new ItemBase()
                {
                    Name = "Book",
                    Amount = (decimal)23.8,
                    IsImported = true
                },
                Amount = 2
            });

            return order;
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
                    IsExemptOffAllTaxes = true
                },
                Amount = 2
            });

            order.OrderItems.Add(new OrderItem
            {
                ItemInOrder = new ItemBase()
                {
                    Name = "Wine",
                    Amount = (decimal) 12.8,
                    IsExemptOffAllTaxes = true
                },
                Amount = 6
            });
            return order;
        }
    }
}
