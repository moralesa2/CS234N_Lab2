using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class CustomerDBTests
    {
        //do setup?

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);

            CustomerDB.DeleteCustomer(c);
            //deleting test data after test is complete
        }

        [Test]
        public void TestDeleteCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            c.CustomerID = CustomerDB.AddCustomer(c);
            //Customer must exist in db for test to work         

            Assert.IsTrue(CustomerDB.DeleteCustomer(c));
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer oldCustomer = new Customer();
            oldCustomer.Name = "Mickey Mouse";
            oldCustomer.Address = "101 Main Street";
            oldCustomer.City = "Orlando";
            oldCustomer.State = "FL";
            oldCustomer.ZipCode = "10101";
            oldCustomer.CustomerID = CustomerDB.AddCustomer(oldCustomer);

            Customer newCustomer = new Customer();           
            newCustomer.Name = "Minnie Mouse";
            newCustomer.Address = "123 Main Street";
            newCustomer.City = "Las Vegas";
            newCustomer.State = "NV";
            newCustomer.ZipCode = "12345";
            newCustomer.CustomerID = oldCustomer.CustomerID;

            Assert.IsTrue(CustomerDB.UpdateCustomer(oldCustomer, newCustomer));
            Assert.AreEqual(oldCustomer.CustomerID, newCustomer.CustomerID);
            Assert.AreNotEqual(oldCustomer.Name, newCustomer.Name);
            
            CustomerDB.DeleteCustomer(newCustomer);
            //deleting test data after test is complete
        }

    }
}
