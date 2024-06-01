using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{

    public class Order
    {

        private List<Product> _product;

        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _product = new List<Product>();
        }

        public void AddProductToOrder(Product product)
        {
            
            _product.Add(product);

        }


        public decimal CalculateTotalCost()
        {
            decimal total = 0;
            foreach (var product in _product)
            {
                total += product.TotalCost();
            }

            total += _customer.LivesInUSA() ? 5 : 35;

            return total;
        }


        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var product in _product)
            {
                sb.AppendLine($"{product._name} (ID: {product._id})");
            }
            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            sb.AppendLine(_customer._name);
            sb.AppendLine(_customer.GetAddress().GetFullAddress());
            return sb.ToString();
        }
    }


}