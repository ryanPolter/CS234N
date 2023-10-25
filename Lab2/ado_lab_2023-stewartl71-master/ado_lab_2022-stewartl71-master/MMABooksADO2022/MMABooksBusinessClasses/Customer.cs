using System;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        // there are several warnings in this file related to nullable properties and return values.
        // you can ignore them
        public Customer() { }

        public Customer(int id, string name, string address, string city, string state, string zipcode)
        {
            CustomerID = id;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipcode;
        }

        //  Instance variables
        private int customerID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zipcode;

        public int CustomerID 
        {
            get
            {
                return customerID;
            }

            set
            {
                if (value > 0)
                    customerID = value;
                else
                    throw new ArgumentOutOfRangeException("CustomerID must be a positive integer.");
            } 
        }

        public string Name 
        {
            get
            {
                return name;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                    name = value;
                else
                    throw new ArgumentOutOfRangeException("Name must be at least one character and less than 100 characters");
            } 
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 50)
                    address = value;
                else
                    throw new ArgumentOutOfRangeException("Address must be at least one character and less than 50 characters");
            }
        
        }
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 20)
                    city = value;
                else
                    throw new ArgumentOutOfRangeException("City must be at least one character and less than 20 characters");
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (value.Length > 0 && value.Length <= 2)
                    state = value;
                else
                    throw new ArgumentOutOfRangeException("State refers to the state code and must be 2 characters");
            }
        }

        public string ZipCode
        {
            get
            {
                return zipcode;
            }

            set
            {
                if (value.Length >= 5 && value.Length <= 15)
                    zipcode = value;
                else
                    throw new ArgumentOutOfRangeException("Zipcode must be at least 5 numbers and less than or equal to 15 numbers");
            }
        }

        public override string ToString()
        {
            return CustomerID + ", " + Name + ", " + Address + ", " + City + ", " + State + ", " + ZipCode;
        }
        /*
        public override string ToString()
        {
            return base.ToString();
        }
        */
    }
}
