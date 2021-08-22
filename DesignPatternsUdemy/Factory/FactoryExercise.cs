using System;
using System.Collections.Generic;

namespace DesignPatternsUdemy.Factory
{
    public class FactoryExercise
    {
        public FactoryExercise()
        {
        }
    }

    public class Person
    {
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public interface IPersonFactory
    {
        Person CreatePerson(string name);
    }

    public class PersonFactory : IPersonFactory
    {
        public List<Person> factories =
            new List<Person>();

        public Person CreatePerson(string name)
        {
            Person person = new Person(factories.Count, name);
            factories.Add(person);
            return person;
        }

        public void PrintFactory()
        {
            foreach (var person in factories)
            {
                Console.WriteLine(person);
            }
        }
    }
}
