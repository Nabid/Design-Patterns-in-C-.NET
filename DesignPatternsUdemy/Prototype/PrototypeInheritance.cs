using System;
namespace DesignPatternsUdemy.Prototype
{
    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    //public static class ExtentionMethods
    //{
    //    public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new()
    //    {
    //        return item.DeepCopy();
    //    }
    //}

    public static class PrototypeInheritance
    {
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

            public void CopyTo(Address target)
            {
                target.StreetName = StreetName;
                target.HouseNumber = HouseNumber;
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

            public void CopyTo(Person target)
            {
                target.Names = (string[])Names.Clone();
                target.Address = Address.DeepCopy();
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

            public void CopyTo(Employee target)
            {
                base.CopyTo(target);
                target.Salary = Salary;
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

            Employee johnCopy = john.DeepCopy<Employee>();
            johnCopy.Names = new []{ "Smith", "Johan" };

            Console.WriteLine(johnCopy);
        }
    }
}
