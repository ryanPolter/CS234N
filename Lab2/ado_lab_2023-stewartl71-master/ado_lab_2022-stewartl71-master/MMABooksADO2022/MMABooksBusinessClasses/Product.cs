using System;
using System.Collections.Generic;
using System.Text;


namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string productCode, string description, decimal unitPrice, int onHandQuantity)
        {
            ProductCode = productCode;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }

        //  Instance Variables
        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;

        public string ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 10)
                    productCode = value;
                else
                    throw new ArgumentOutOfRangeException("Product Code must be at least one character and less than 10 characters");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 50)
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("The description must be at least one character and less than 50 characters");
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value > 0)
                    unitPrice = value;
                else
                    throw new ArgumentOutOfRangeException("Unit price must be greater than 0 and only contain up to 4 decimal places");
            }
        }

        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }
            set
            {
                if (value >= 0)
                    onHandQuantity = value;
                else
                    throw new ArgumentOutOfRangeException("On hand quantity must be a positive integer");
            }
        }
        public override string ToString()
        {
            return ProductCode + ", " + Description + ", " + UnitPrice + ", " + OnHandQuantity;
        }


    }
}
