using System;

namespace Encapsulation
{

    public class Product
    {

        public string _name { get; set; }

        public string _id { get; set; }

        private decimal _price { get; set; }

        private int _quantity { get; set; }

        
        public Product(string name, string id, decimal price, int quantity)
        {
            _name = name;
            _id = id;
            _price = price;
            _quantity = quantity;
        }


       
        public decimal TotalCost()
        {
            return _price * _quantity;
        }
    }


}