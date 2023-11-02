﻿using System;
using System.Collections.Generic;
using System.Text;

using MMABooksTools;
using MMABooksProps;
using MMABooksDB;

namespace MMABooksBusiness
{
    public class Product : BaseBusiness
    {

        public int ProductID
        {
            get
            {
                return ((ProductProps)mProps).ProductID;
            }
        }

        public String ProductCode
        {
            get
            {
                return ((ProductProps)mProps).ProductCode;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).ProductCode))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 10)
                    {
                        mRules.RuleBroken("ProductCode", false);
                        ((ProductProps)mProps).ProductCode = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Name must be no more than 10 characters long.");
                    }
                }
            }
        }

        public String Address
        {
            get
            {
                return ((ProductProps)mProps).Description;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).Description))
                {
                    if (value.Trim().Length >= 1 && value.Trim().Length <= 50)
                    {
                        mRules.RuleBroken("Description", false);
                        ((ProductProps)mProps).Description = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Address must be no more than 50 characters long.");
                    }
                }
            }
        }

        public Decimal UnitPrice
        {
            get
            {
                return ((ProductProps)mProps).UnitPrice;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).UnitPrice))
                {
                    if (value >= 0M)
                    {
                        mRules.RuleBroken("UnitPrice", false);
                        ((ProductProps)mProps).UnitPrice = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("UnitPrice must be at least $0.01.");
                    }
                }
            }
        }

        public int OnHandQuantity
        {
            get
            {
                return ((ProductProps)mProps).OnHandQuantity;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).OnHandQuantity))
                {
                    if (value >= 0)
                    {
                        mRules.RuleBroken("OnHandQuantity", false);
                        ((ProductProps)mProps).OnHandQuantity = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("OnHandQuantity must be zero or a positive integer.");
                    }
                }
            }
        }


        public override object GetList()
        {
            List<Product> customers = new List<Product>();
            List<ProductProps> props = new List<ProductProps>();


            props = (List<ProductProps>)mdbReadable.RetrieveAll();
            foreach (ProductProps prop in props)
            {
                Product p = new Product(prop);
                customers.Add(p);
            }

            return customers;
        }

        protected override void SetDefaultProperties()
        {
            //  Okay to be empty

        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("ProductCode", true);
            mRules.RuleBroken("Description", true);
            mRules.RuleBroken("UnitPrice", true);
            mRules.RuleBroken("OnHandQuantity", true);
        }

        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();

            mdbReadable = new ProductDB();
            mdbWriteable = new ProductDB();
        }

        #region constructors
        /// <summary>
        /// Default constructor - gets the connection string - assumes a new record that is not in the database.
        /// </summary>
        public Product() : base()
        {
        }

        /// <summary>
        /// Calls methods SetUp() and Load().
        /// Use this constructor when the object is in the database AND the connection string is in a config file
        /// </summary>
        /// <param name="key">ID number of a record in the database.
        /// Sent as an arg to Load() to set values of record to properties of an 
        /// object.</param>
        public Product(int key)
            : base(key)
        {
        }

        private Product(ProductProps props)
            : base(props)
        {
        }

        #endregion
    }
}