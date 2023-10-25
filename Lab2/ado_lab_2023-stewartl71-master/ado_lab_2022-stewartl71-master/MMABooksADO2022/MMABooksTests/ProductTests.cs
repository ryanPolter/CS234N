using MMABooksBusinessClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        public void SetUp()
        {
            def = new Product();
            p = new Product("AB12", "DefaultProductDescription", 150.5000M, 48);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0M, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);

            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreEqual("DefaultProductDescription", p.Description);
            Assert.AreNotEqual(null, p.UnitPrice);
            Assert.AreNotEqual(null, p.OnHandQuantity);
        }

        [Test]
        public void TestProductSetters()
        {
            //  Making sure everything starts off right
            Assert.AreEqual("AB12", p.ProductCode);
            Assert.AreEqual("DefaultProductDescription", p.Description);
            Assert.AreEqual(150.5000M, p.UnitPrice);
            Assert.AreEqual(48, p.OnHandQuantity);

            //  Variables that will be set 
            string newProductCode = "ZX98";
            string newDescription = "A New Description";
            decimal newUnitPrice = 200.0000M;
            int newOnHandQuantity = 76;

            //  Product Code setter
            p.ProductCode = newProductCode;
            Assert.AreNotEqual("AB12", p.ProductCode);
            Assert.AreEqual(newProductCode, p.ProductCode);

            //  Description setter
            p.Description = newDescription;
            Assert.AreNotEqual("DefaultProductDescription", p.Description);
            Assert.AreEqual(newDescription, p.Description);

            //  Unit Price Setter
            p.UnitPrice = newUnitPrice;
            Assert.AreNotEqual(150.5000M, p.UnitPrice);
            Assert.AreEqual(newUnitPrice, p.UnitPrice);

            //  On Hand Quantity setter
            p.OnHandQuantity = newOnHandQuantity;
            Assert.AreNotEqual(48, p.OnHandQuantity);
            Assert.AreEqual(newUnitPrice, p.UnitPrice);
        }

        [Test]
        public void TestProductToString()
        {
            Product product1 = new Product("ZX98", "ProdDescripiton", 140.0000M, 15);
            Assert.IsTrue(product1.ToString().Contains("ZX98"));
            Assert.IsTrue(product1.ToString().Contains("ProdDescripiton"));
            Assert.IsTrue(product1.ToString().Contains("140.0000"));
            Assert.IsTrue(product1.ToString().Contains("15"));
        }
    }
}
