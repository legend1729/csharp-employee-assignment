using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Employee
    {
        public int EmployeeId{get; set;}

        public string Name{get; set;}

        public int Age{get; set;}

        public char Gender{get; set;}

        public int Salary{get; set;}

        public List<Address> Addresses;

        public Employee(){}
    }
}