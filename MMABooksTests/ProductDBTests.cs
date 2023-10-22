using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            Product p = new Product();
            p.ProductCode = "T35T";
            p.Description = "Test description1";
            p.UnitPrice = 101.01M;
            p.OnHandQuantity = 1;

            ProductDB.AddProduct(p);
            Assert.AreEqual("Test description1", p.Description);

            ProductDB.DeleteProduct(p);
            //deleting test data for cleanup & to avoid duplicate entry exception when test run more than once
        }

        [Test]
        public void TestDeleteProduct()
        {
            Product p = new Product();
            p.ProductCode = "TESTCODE";
            p.Description = "Test description2";
            p.UnitPrice = 102.01M;
            p.OnHandQuantity = 3;

            ProductDB.AddProduct(p);
            Assert.IsTrue(ProductDB.DeleteProduct(p));
        }

        [Test]
        public void TestUpdateProduct()
        {

        }
    }
}
