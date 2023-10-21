using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]

        public void Setup()
        {
            def = new Product();
            p = new Product("A1BC", "Test Product", 100.10M, 10);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);

            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreNotEqual(null, p.Description);
            Assert.AreNotEqual(0, p.UnitPrice);
            Assert.AreNotEqual(0, p.OnHandQuantity);
        }

        [Test]
        public void TestProductCodeSetter()
        {
            p.ProductCode = "A2BC";
            Assert.AreNotEqual("A1BC", p.ProductCode);
            Assert.AreEqual("A2BC", p.ProductCode);
        }

        [Test]
        public void TestSettersProductCodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "A123B123C123");
        }

        [Test]
        public void TestSettersProductCodeStringEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "");
        }

        [Test]
        public void TestDescriptionSetter()
        {
            p.Description = "Testing description setter";
            Assert.AreNotEqual("Test Product", p.Description);
            Assert.AreEqual("Testing description setter", p.Description);
        }

        [Test]
        public void TestSettersDescriptionTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "This description is too long This description is too longThis description is too longThis description is too long");
        }

        [Test]
        public void TestSettersDescriptionStringEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "");
        }

        [Test]
        public void TestUnitPriceSetter()
        {
            p.UnitPrice = 59.50M;
            Assert.AreNotEqual(100.01, p.UnitPrice);
            Assert.AreEqual(59.50, p.UnitPrice);
        }

        [Test]
        public void TestSettersUnitPriceInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = 0);
        }

        [Test]
        public void TestOnHandQuantitySetter()
        {
            p.OnHandQuantity = 8;
            Assert.AreNotEqual(10, p.OnHandQuantity);
            Assert.AreEqual(8, p.OnHandQuantity);
        }

        [Test]
        public void TestSettersOnHandQuantityInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.OnHandQuantity = -1);
        }

        [Test]
        public void TestProductToString()
        {
            p = new Product("AB12", "Test", 6.50M, 3);
            Assert.IsTrue(p.ToString().Contains("AB12"));
            Assert.IsTrue(p.ToString().Contains("Test"));
            Assert.IsTrue(p.ToString().Contains("6.50"));
            Assert.IsTrue(p.ToString().Contains("3"));
        }
    }
}
