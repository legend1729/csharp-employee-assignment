namespace Assignment
{ 
    class Program 
    { 
        static int i = 1; 
        public static int IncrementId { get { return i++; } } 
        enum TaxSlab 
        { 
            FirstSlab=5, SecondSlab=20, LastSlab=30 
        }

        static void Main(string[] args) 
        { 
            int x = 0; 
            List<Employee> Employees = new List<Employee> 
            { 
                new Employee()
                {
                    EmployeeId = IncrementId, Name="Satyam Prakash", Age=22, Gender = 'M', Salary=1300000, 
                    Addresses = new List<Address> 
                    { 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Patna", State="Bihar", IsPresentAddress=true }, 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Bangalore", State="Karnataka", IsPresentAddress=false } 
                    } 
                },

                new Employee()
                { 
                    EmployeeId = IncrementId, Name="Shubham Singh", Age=21, Gender = 'M', Salary=1500000,
                    Addresses = new List<Address> 
                    { 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Jamshedpur", State="Bihar", IsPresentAddress=true }, 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Bangalore", State="Karnataka", IsPresentAddress=false } 
                    } 
                }, 
                
                new Employee()
                { 
                    EmployeeId = IncrementId, Name="Suresh Sagi", Age=35, Gender = 'M', Salary=2500000, 
                    Addresses = new List<Address> 
                    { 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Mumbai", State="Maharastra", IsPresentAddress=false }, 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Bangalore", State="Karnataka", IsPresentAddress=true } 
                    } 
                }, 

                new Employee()
                { 
                    EmployeeId = IncrementId, Name="Anil Gone", Age=30, Gender = 'M', Salary=2000000, 
                    Addresses = new List<Address> 
                    { 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Chennai", State="Tamil Nadu", IsPresentAddress=true }, 
                        new Address{AddressLine1="AddressLine1", AddressLine2 = "AddressLine2", City="Bangalore", State="Karnataka", IsPresentAddress=false } 
                    } 
                }, 

                new Employee()
                { 
                    EmployeeId = IncrementId, Name="Prateek Rathore", Age=30, Gender = 'M', Salary=1200000 
                } 
            }; 
                
            while(true) 
            {
                Console.WriteLine("Please select an option: \n" + 
                "1. Display all employees' details.\n" + 
                "2. Find the employee with 2nd lowest salary.\n" + 
                "3. Find out which employee hasn't provided an address.\n" + 
                "4. Find Employee Tax amount as per India Old tax slabs rates.\n" + 
                "5. Find out how many employees are currently working in Bangalore.\n" + 
                "6. Find out how many employess are currently not working from Bangalore.\n" + 
                "Any other number to Exit. \n");
                
                Console.Write("Please enter a number: "); 
                
                try 
                { 
                    x = Convert.ToInt32(Console.ReadLine()); 
                } 
                catch(Exception e) 
                { 
                    Console.WriteLine(e.Message + " Please enter a number.\n"); 
                    continue; 
                }
                
                switch(x) 
                { 
                    case 1: 
                    { 
                        Console.WriteLine("\n---- All Employee Details ----\n"); 
                        printEmployees(Employees); break; 
                    } 
                    
                    case 2: 
                    { 
                        getEmpWith2ndLowestSalary(Employees); 
                        break; 
                    } 

                    case 3: 
                    { 
                        getEmpWithNullAddress(Employees); 
                        break; 
                    } 
                    
                    case 4: 
                    { 
                        getTaxOfEmp(Employees); 
                        break; 
                    } 
                    
                    case 5: 
                    { 
                        getEmpInBnglr(Employees);
                        break; 
                    } 
                    
                    case 6: 
                    { 
                        getEmpNotInBnglr(Employees); 
                        break; 
                    } 
                    
                    default: 
                    { 
                        Console.WriteLine("...Thank you...");
                        return; 
                    } 
                } 
            }
        } 
        public static void printEmployees(List<Employee> Employees, double tax=-1) 
        { 
            foreach (Employee emp in Employees) 
            { 
                Console.WriteLine($"\nEmployee ID : {emp.EmployeeId}"); 
                Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, Gender: {emp.Gender}, Salary: Rs {emp.Salary}"); 
                if (emp.Addresses != null) 
                { 
                    foreach (Address add in emp.Addresses) 
                    { 
                        Console.WriteLine($"Address {emp.Addresses.IndexOf(add) + 1}: { add.AddressLine1}, { add.AddressLine2}, " + $"{ add.City}, { add.State} {((add.IsPresentAddress) ? "(Present address)" : "")} "); 
                    } 
                } 
                if(tax!=-1) 
                { 
                    Console.WriteLine($"Tax Amount: Rs {tax}"); 
                } 
                Console.WriteLine("\n"); 
            } 
        } 
        public static void getEmpWithNullAddress(List<Employee> Employees) 
        { 
            Console.WriteLine("\nEmployees who haven't provided address: \n"); 
            List<Employee> Emp1 = Employees.Where(e => e.Addresses == null).ToList(); 
            printEmployees(Emp1); 
        } 
        public static void getEmpWith2ndLowestSalary(List<Employee> Employees) 
        {  
            Employee emp = Employees.Where(e => e.Salary > Employees.Min(e => e.Salary)).OrderBy(e => e.Salary).First(); 
            Console.WriteLine($"\nEmployee with 2nd lowest salary: {emp.Name}\n");
        } 
        private static void getEmpInBnglr(List<Employee> Employees) 
        { 
            int x = Employees.Count(e => (e.Addresses == null)? false: e.Addresses.Any(a => a.City == "Bangalore" && a.IsPresentAddress)); 
            Console.WriteLine($"\nEmployees in Bangalore: {x}\n"); 
        } 
        private static void getEmpNotInBnglr(List<Employee> Employees) 
        { 
            int x = Employees.Count(e => (e.Addresses == null) ? false : e.Addresses.Any(a => a.City == "Bangalore" && !a.IsPresentAddress)); 
            Console.WriteLine($"\nEmployees not in Bangalore: {x}\n"); 
        } 
        // Find Employee Tax amount as per India Old tax slabs rates 
        // Rs.250000/- No Tax 
        // Rs.250001/- to Rs.500000 is 5% Tax 
        // Rs.500001/- to Rs.1000000 is 20% Tax 
        // More than Rs.1000001/ is 30% Tax 
        //(EX: - If the person is drawing Rs. 1000000 of salary then tax will be calculated as like this 
        //250000*0+250000*0.05+500000*0.2 = 125000 (0+12500+100000 ) 
        private static void getTaxOfEmp(List<Employee> Employees) 
        { 
            Console.WriteLine("\nEmployees with their Tax Amount: \n"); 
            foreach (Employee emp in Employees) 
            { 
                double d = emp.Salary; double tax = 0.0; 
                if (d <= 250000) 
                { 
                    tax = 0.0; 
                } 
                else if (d <= 500000) 
                { 
                    tax = (d - 250000) * 0.01 * (int)TaxSlab.FirstSlab; 
                } 
                else if (d <= 1000000) 
                { 
                    tax = 250000 * 0.01 * (int)TaxSlab.FirstSlab + (d - 500000) * 0.01 * (int)TaxSlab.SecondSlab; 
                } 
                else if (d > 1000000) 
                { 
                    tax = 250000 * 0.01 * (int)TaxSlab.FirstSlab + 
                    (500000) * 0.01 * (int)TaxSlab.SecondSlab + 
                    (d - 1000000) * 0.01 * (int)TaxSlab.LastSlab; 
                } 
                else 
                { 
                    Console.WriteLine("Invalid Salary"); 
                    continue; 
                } 
                List<Employee> e1 = new List<Employee> { emp }; 
                printEmployees(e1, tax); 
            } 
        } 
    } 
}