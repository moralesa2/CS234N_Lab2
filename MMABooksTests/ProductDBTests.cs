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
            p.UnitPrice = 102.01m;
            p.OnHandQuantity = 3;

            ProductDB.AddProduct(p);
            Assert.IsTrue(ProductDB.DeleteProduct(p));
        }

        [Test]
        public void TestUpdateProduct()
        {
            Product oldProduct = new Product();
            oldProduct.ProductCode = "TEST";
            oldProduct.Description = "Old product test";
            oldProduct.UnitPrice = 50.50m;
            oldProduct.OnHandQuantity = 1;
            ProductDB.AddProduct(oldProduct);

            Product newProduct = new Product();
            newProduct.ProductCode = oldProduct.ProductCode;
            newProduct.Description = "New product test";
            newProduct.UnitPrice = 75.15m;
            newProduct.OnHandQuantity = 2;
            
            Assert.IsTrue(ProductDB.UpdateProduct(oldProduct, newProduct));
            Assert.AreEqual(oldProduct.ProductCode, newProduct.ProductCode);
            Assert.AreNotEqual("Old product test", newProduct.Description);

            ProductDB.DeleteProduct(newProduct);
            //Cleanup
        }
    }
}
