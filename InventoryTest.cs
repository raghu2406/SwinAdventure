using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SwinAdventure
{
    // ... (other classes and namespaces remain unchanged)

    [TestFixture]
    public class InventoryTest
    {
        Item shovel = new Item(new string[] { "shovel" }, "a shovel", "This is a shovel");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a sword");

        [SetUp]
        public void Setup()
        {
            // No setup needed for now
        }

        [Test]
        public void TestFindItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Assert.IsTrue(i.HasItem(shovel.FirstId())); // Corrected method call
        }
        [Test]
        public void TestFetchItems()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            Item fetchItem = i.Fetch(shovel.FirstId());

            Assert.IsTrue(fetchItem == shovel);
            Assert.IsTrue(i.HasItem(shovel.FirstId()));
        }
        [Test]
        public void TestTakenItem()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            i.Take(shovel.FirstId());
            Assert.IsFalse(i.HasItem(shovel.FirstId()));
        }
        [Test]
        public void TestItemList()
        {
            Inventory i = new Inventory();
            i.Put(shovel);
            i.Put(sword);
            Assert.IsTrue(i.HasItem(shovel.FirstId()));
            Assert.IsTrue(i.HasItem(sword.FirstId()));

            string expctOutput = "a shovel (shovel)\n" + "a sword (sword)\n";
            Assert.AreEqual(i.ItemList, expctOutput);
        }
    }
}