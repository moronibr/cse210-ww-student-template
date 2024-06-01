using System;

namespace Encapsulation
{
    public class Customer
    {
       
       public Address _address;
       public string _name {get; set;}


       public Customer(Address address, string name)
       {
           _address = address;
           _name = name;
       }
       
        public bool LivesInUSA()
        {
            return _address.IsInUSA();
        }

        public Address GetAddress()
        {
            return _address;
        }

    }
}