using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]

        public void Setup()
        {
            def = new Customer();
            c = new Customer(1, "Donald, Duck", "101 Main Street", "Orlando", "FL", "10001" );
        }

        [Test] 
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Daisy, Duck";
            Assert.AreNotEqual("Donald, Duck", c.Name);
            Assert.AreEqual("Daisy, Duck", c.Name);
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        }

        [Test]
        public void TestSettersNameTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "");
        }

        [Test]
        public void TestCustomerIDSetter()
        {
            c.CustomerID = 1234;
            Assert.AreNotEqual(0000, c.CustomerID);
            Assert.AreEqual(1234, c.CustomerID);
        }

        [Test]
        public void TestSettersCustomerIDInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.CustomerID = 0);
        }

        [Test]
        public void TestAddressSetter()
        {
            c.Address = "123 Main Street";
            Assert.AreNotEqual("101 Main Street", c.Address);
            Assert.AreEqual("123 Main Street", c.Address);
        }

        [Test]
        public void TestSettersAddressTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "012345678901234567890123456789012345678901234567890");
        }

        [Test]
        public void TestSettersAddressTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "");
        }

        [Test] 
        public void TestCitySetter()
        {
            c.City = "Eugene";
            Assert.AreNotEqual("Orlando", c.City);
            Assert.AreEqual("Eugene", c.City);
        }

        [Test]
        public void TestSettersCityTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "012345678901234567890");
        }

        [Test]
        public void TestSettersCityTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.City = "");
        }

        [Test]
        public void TestStateSetter()
        {
            c.State = "OR";
            Assert.AreNotEqual("Fl", c.State);
            Assert.AreEqual("OR", c.State);
        }

        [Test]
        public void TestSettersStateTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "012");
        }

        [Test]
        public void TestSettersStateTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.State = "");
        }

        [Test]
        public void TestZipcodeSetter()
        {
            c.ZipCode = "97405";
            Assert.AreNotEqual("10001", c.ZipCode);
            Assert.AreEqual("97405", c.ZipCode);
        }

        [Test]
        public void TestSettersZipcodeTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "01234567890123456");
        }

        [Test]
        public void TestSettersZipcodeTooShort()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "0123");
        }

        [Test]
        public void TestCustomerToString()
        {
            c = new Customer(1234, "Jane, Doe", "123 Main Street", "Eugene", "OR", "97405");
            Assert.IsTrue(c.ToString().Contains("1234"));
            Assert.IsTrue(c.ToString().Contains("Jane, Doe"));
            Assert.IsTrue(c.ToString().Contains("123 Main Street"));
            Assert.IsTrue(c.ToString().Contains("Eugene"));
            Assert.IsTrue(c.ToString().Contains("OR"));
            Assert.IsTrue(c.ToString().Contains("97405"));
        }
    }
}
