using System;
namespace DesignPatternsUdemy.Prototype
{
    public static class ExplicitDeepCopy
    {
        interface IDeepCopyable<T>
        {
            T DeepCopy();
        }

        class Address : IDeepCopyable<Address>
        {
            public string StreetName { get; set; }
            public string HouseNumber { get; set; }

            public Address()
            {
            }

            public Address(string streetName, string houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }


            public override string ToString()
            {
                return $"StreetName: {StreetName}, HouseNumber: {HouseNumber}";
            }

            public Address DeepCopy()
            {
                return (Address)MemberwiseClone();
            }
        }

        class Person : IDeepCopyable<Person>
        {
            public string[] Names { get; set; }
            public Address Address { get; set; }

            public Person()
            {

            }

            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public override string ToString()
            {
                return $"Name: {string.Join(",", Names)}, Address: {Address}";
            }

            public Person DeepCopy()
            {
                return new Person((string[])Names.Clone(), Address.DeepCopy());
            }
        }

        class Employee : Person, IDeepCopyable<Employee>
        {
            public int Salary { get; set; }
            public Employee()
            {

            }

            public Employee(string[] names, Address address) : base(names, address)
            {
            }

            public override string ToString()
            {
                return $"{base.ToString()}, Salary: {Salary}";
            }

            Employee IDeepCopyable<Employee>.DeepCopy()
            {
                return new Employee((string[])Names.Clone(), Address.DeepCopy());
            }
        }

        public static void Demo()
        {
            var john = new Employee
            {
                Names = new[] { "John", "Doe" },
                Address = new Address
                {
                    StreetName = "Krombacher str.",
                    HouseNumber = "59"
                },
                Salary = 3500
            };

            Console.WriteLine(john);

            var johnCopy = john.DeepCopy();
            johnCopy.Names = new []{ "Smith", "Johan" };

            Console.WriteLine(johnCopy);
        }
    }
}
