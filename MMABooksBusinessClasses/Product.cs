using System;
using System.ComponentModel.Design;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;

        public Product() { }
        public Product(string code, string description, decimal price, int quantity) 
        {
            ProductCode = code;
            Description = description;
            UnitPrice = price;
            OnHandQuantity = quantity;
        }

        public string ProductCode 
        { 
            get
            {  
                return productCode; 
            }
            set
            {
                if (value.Length > 0 && value.Length <= 10)
                    productCode = value.ToUpper();
                else
                    throw
                        new ArgumentOutOfRangeException("Product code must be at least 1 character and not more than 10 characters. ");
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
                if (value.Trim().Length > 0 && value.Trim().Length <= 50)
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("Description must be at least 1 character and not more than 50 characters. ");
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
                    throw new ArgumentOutOfRangeException("Unit price must be a positive decimal. ");
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
                    throw new ArgumentOutOfRangeException("On hand quantity must an integer greater than or equal to 0. ");
            }
        }

        public override string ToString()
        {
            return ProductCode + ", " + Description + ", " + UnitPrice + ", " + OnHandQuantity;
        }
    }
}
