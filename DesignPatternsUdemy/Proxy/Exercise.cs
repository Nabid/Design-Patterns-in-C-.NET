using System;
namespace DesignPatternsUdemy.Proxy
{
    public class Exercise
    {
        public Exercise()
        {
        }
    }

    public interface IPerson
    {
        public string Drink();
        public string Drive();
        public string DrinkAndDrive();
    }

    public class Person : IPerson
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private Person person;

        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }

        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }

        public string Drink()
        {
            return Age < 18 ? "too young" : person.Drink();
        }

        public string Drive()
        {
            return Age < 16 ? "too young" : person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }
}
