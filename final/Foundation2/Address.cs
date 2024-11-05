using System;

namespace Encapsulation
{

    public class Address 
    {

        private string _street { get; set; }
        private string _city { get; set; }
        private string _stateProve { get; set; }
        
        public string _country { get; set; }

        public Address(string street, string city, string stateProve, string country)
        {
            _street = street;
            _city = city;
            _stateProve = stateProve;
            _country = country;
        }

        public bool IsInUSA()
        {
            return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

         public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateProve}\n{_country}";
        }

    }
    

}