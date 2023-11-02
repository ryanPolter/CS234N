
using NUnit.Framework;

using MMABooksProps;
using MMABooksDB;

using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;

using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using MMABooksTools;
using System.Data.Common;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {
        ProductDB db;

        [SetUp]
        public void ResetData()
        {
            db = new ProductDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestRetrieve()
        {
            ProductProps p = (ProductProps)db.Retrieve("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode);
            Assert.AreEqual("Murach's ASP.NET 4 Web Programming with C# 2010", p.Description);
        }


        [Test]
        public void TestRetrieveAll()
        {
            List<ProductProps> list = (List<ProductProps>)db.RetrieveAll();
            Assert.AreEqual(16, list.Count);
        }


        [Test]
        public void TestCreate()
        {
            ProductProps p = new ProductProps();
            p.ProductID = 100;
            p.ProductCode = "NEWW";
            p.Description = "A new product";
            p.UnitPrice = 150;
            p.OnHandQuantity = 600;
            p = (ProductProps)db.Create(p);
            ProductProps p2 = (ProductProps)db.Retrieve(p.ProductCode);
            Assert.AreEqual(p.GetState(), p2.GetState());
        }

        [Test]
        public void TestDelete()
        {
            ProductProps p = (ProductProps)db.Retrieve("A4CS");
            Assert.True(db.Delete(p));
            Assert.Throws<Exception>(() => db.Retrieve("A4CS"));
        }

        // What 
        [Test]
        public void TestUpdate()
        {
            ProductProps p = (ProductProps)db.Retrieve("A4CS");
            p.ProductCode = "ABCD";
            Assert.True(db.Update(p));  //
            p = (ProductProps)db.Retrieve("ABCD");
            Assert.AreEqual("ABCD", p.ProductCode);
        }

    }
}