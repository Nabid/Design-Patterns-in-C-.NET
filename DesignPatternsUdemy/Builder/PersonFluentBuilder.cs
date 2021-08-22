using System;
namespace DesignPatternsUdemy
{
    public interface IPerson
    {
        string ToString();
    }

    public class Person : IPerson
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"Name = {Name}, Position = {Position}";
        }

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();
    }

    public abstract class PersonBuilder
    {
        public Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    // recursive generics
    public class PersonInfoBuilder<SELF> : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}
