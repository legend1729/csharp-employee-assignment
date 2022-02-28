using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Address
    {
        public string AddressLine1{get ; set;}
        public string AddressLine2{get; set;}
        public string City{get; set;}
        public string State{get; set;}
        public bool IsPresentAddress{get; set;}
        public Address(){}
    }
}