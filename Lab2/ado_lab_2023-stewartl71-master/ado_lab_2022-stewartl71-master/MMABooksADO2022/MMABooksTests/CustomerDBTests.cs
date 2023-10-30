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
        }

        [Test]
        public void TestDeleteCustomer()
        {
            //  Creating a new customer to then delete
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);

            //  Making sure customer w/ID is present
            Assert.IsNotNull(CustomerDB.GetCustomer(customerID));

            //  Deleting customer and checking for successful deletion 
            //      by asserting that the ID is null
            CustomerDB.DeleteCustomer(c);
            Assert.IsNull(CustomerDB.GetCustomer(customerID));
        }

        [Test]
        public void TestUpdateCustomer()
        {
            //  Creating a new customer to then update
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";
            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);

            //  Making sure everything checks out for pre-updated customer
            Assert.AreEqual("Mickey Mouse", c.Name);
            Assert.AreEqual("101 Main Street", c.Address);
            Assert.AreEqual("Orlando", c.City);
            Assert.AreEqual("FL", c.State);
            Assert.AreEqual("10101", c.ZipCode);
            Assert.AreEqual(customerID, c.CustomerID);

            //  Updating the customer
            Customer uC = new Customer();
            uC.Name = "Donald Duck";
            uC.Address = "202 Sub Street";
            uC.City = "Eugene";
            uC.State = "OR";
            uC.ZipCode = "20202";
            CustomerDB.UpdateCustomer(c, uC);

            //  Asserting the old values are out and new values are in
            Assert.AreNotEqual("Mickey Mouse", c.Name);
            Assert.AreNotEqual("101 Main Street", c.Address);
            Assert.AreNotEqual("Orlando", c.City);
            Assert.AreNotEqual("FL", c.State);
            Assert.AreNotEqual("10101", c.ZipCode);

            Assert.AreEqual("Donald Duck", c.Name);
            Assert.AreEqual("202 Sub Street", c.Address);
            Assert.AreEqual("Eugene", c.City);
            Assert.AreEqual("OR", c.State);
            Assert.AreEqual("20202", c.ZipCode);
            Assert.AreEqual(customerID, c.CustomerID);
        }
    }
}
