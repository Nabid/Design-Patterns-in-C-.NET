using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPatternsUdemy.Prototype
{
    public static class ExtentionMethods
    {
        /// <summary>
        /// [Serializable] needed to all extented classes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        /// <summary>
        /// [Serializable] not needed, but default constructor needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }

    public static class CopySerialization
    {
        public class Address
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
        }

        public class Person
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
        }

        public class Employee : Person
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

            // using DeepCopy
            //Employee johnCopy = john.DeepCopy<Employee>();
            //johnCopy.Names = new []{ "Smith", "Johan" };
            //Console.WriteLine(johnCopy);

            // using DeepCOpyXml
            var johnCopy2 = john.DeepCopyXml();
            johnCopy2.Names = new[] { "DeepCopyXml", "IsUsedHere" };
            Console.WriteLine(johnCopy2);
        }
    }
}
