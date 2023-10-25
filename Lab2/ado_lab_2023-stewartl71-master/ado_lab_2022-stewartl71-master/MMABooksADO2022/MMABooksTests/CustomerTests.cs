using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{

    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, "Donald Duck", "101 Main Street", "Orlando", "FL", "10001");
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
            Assert.AreEqual("Donald Duck", c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);

            /*
            Assert.IsNotNull(c);
            Assert.AreEqual("Donald Duck", c.Name);
            Assert.AreEqual("101 Main Street", c.Address);
            Assert.AreEqual("Orlando", c.City);
            Assert.AreEqual("FL", c.State);
            Assert.AreEqual("10001", c.ZipCode);
            */
        }

        /// 
        /// CUSTOMER ID
        /// 
        [Test]
        public void TestCustomerIDGetter()
        {
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCustomerIDSetter()
        {
            int newCode = 5;
            c.CustomerID = newCode;
            Assert.AreEqual(newCode, c.CustomerID);
        }

        [Test]
        public void TestInvalidCustomerIDSet()
        {
            int invalidID = -1;
            try
            {
                c.CustomerID = invalidID;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        /// 
        /// NAME
        /// 
        [Test]
        public void TestNameGetter()
        {
            Assert.AreEqual("Donald Duck", c.Name);

        }

        [Test]
        public void TestNameSetter()
        {
            string newName = "King Mickey";
            c.Name = newName;
            Assert.AreEqual(newName, c.Name);
        }

        [Test]
        public void TestInvalidNameSet()
        {
            string defaultName = c.Name;
            string invalidShortName = " ";
            string invalidLongName = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            //  Making sure defaultName is set correctly
            Assert.AreEqual(defaultName, c.Name);

            //  Testing short name
            try
            {
                c.Name = invalidShortName;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }

            //  Reset
            c.Name = defaultName;

            //  Testing long name
            try
            {
                c.Name = invalidLongName;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        /// 
        /// ADDRESS
        /// 
        [Test]
        public void TestAddressGetter()
        {
            Assert.AreEqual("101 Main Street", c.Address);
        }

        [Test]
        public void TestAddressSetter()
        {
            string newAddress = "202 Sub Street";
            c.Address = newAddress;
            Assert.AreEqual(newAddress, c.Address);
        }

        [Test]
        public void TestInvalidAddressSet()
        {
            string defaultAddress = c.Address;
            string invalidShortAddress = " ";
            string invalidLongAddress = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            //  Making sure defaultName is set correctly
            Assert.AreEqual(defaultAddress, c.Address);

            //  Testing short address
            try
            {
                c.Address = invalidShortAddress;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }

            //  Reset
            c.Address = defaultAddress;

            //  Testing long address
            try
            {
                c.Address = invalidLongAddress;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        /// 
        /// CITY
        /// 
        [Test]
        public void TestCityGetter()
        {
            Assert.AreEqual("Orlando", c.City);
        }

        [Test]
        public void TestCitySetter()
        {
            string newCity = "Miami";
            c.City = newCity;
            Assert.AreEqual(newCity, c.City);
        }

        [Test]
        public void TestInvalidCitySet()
        {
            string defaultCity = c.City;
            string invalidShortCity = " ";
            string invalidLongCity = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            //  Making sure defaultName is set correctly
            Assert.AreEqual(defaultCity, c.City);

            //  Testing short address
            try
            {
                c.City = invalidShortCity;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }

            //  Reset
            c.City = defaultCity;

            //  Testing long address
            try
            {
                c.City = invalidLongCity;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        /// 
        /// STATE
        /// 
        [Test]
        public void TestStateGetter()
        {
            Assert.AreEqual("FL", c.State);
        }

        [Test]
        public void TestStateSetter()
        {
            string newStateCode = "OR";
            c.State = newStateCode;
            Assert.AreEqual(newStateCode, c.State);
        }

        [Test]
        public void TestInvalidStateSet()
        {
            string defaultStateCode = c.State;
            string invalidShortStateCode = " ";
            string invalidLongStateCode = "ABCD";

            //  Making sure defaultName is set correctly
            Assert.AreEqual(defaultStateCode, c.State);

            //  Testing short address
            try
            {
                c.City = invalidShortStateCode;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }

            //  Reset
            c.State = defaultStateCode;

            //  Testing long address
            try
            {
                c.State = invalidLongStateCode;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }
        }

        /// 
        /// ZIPCODE
        /// 
        [Test]
        public void TestZipGetter()
        {
            Assert.AreEqual("10001", c.ZipCode);

        }

        [Test]
        public void TestZipSetter()
        {
            string newZipcode = "20002";
            c.ZipCode = newZipcode;
            Assert.AreEqual(newZipcode, c.ZipCode);
        }

        [Test]
        public void TestInvalidZipSet()
        {
            string defaultZipcode = c.ZipCode;
            string invalidShortZipcode = " ";
            string invalidLongZipcode = "123456789101112131415";

            //  Making sure defaultName is set correctly
            Assert.AreEqual(defaultZipcode, c.ZipCode);

            //  Testing short address
            try
            {
                c.ZipCode = invalidShortZipcode;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }

            //  Reset
            c.State = defaultZipcode;

            //  Testing long address
            try
            {
                c.ZipCode = invalidLongZipcode;
                Assert.Fail("If the exception IS NOT thrown, the property IS NOT doing the right thing.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass("If the exception IS thrown, the property IS doing the right thing.");
            }

        }

        [Test]
        public void TestCustomerToString()
        {
            Customer customer1 = new Customer(10, "Mickey Mouse", "202 Sub Street", "Oregon", "OR", "20002");
            Assert.IsTrue(customer1.ToString().Contains("10"));
            Assert.IsTrue(customer1.ToString().Contains("Mickey Mouse"));
            Assert.IsTrue(customer1.ToString().Contains("202 Sub Street"));
            Assert.IsTrue(customer1.ToString().Contains("Oregon"));
            Assert.IsTrue(customer1.ToString().Contains("OR"));
            Assert.IsTrue(customer1.ToString().Contains("20002"));
        }
    }
}
