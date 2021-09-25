using System;
namespace DesignPatternsUdemy.Decorator
{
    public class Exercise
    {
        public static void Demo()
        {
            var dragon = new Dragon
            {
                Age = 5
            };
            Console.WriteLine(dragon);
        }
    }

    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        public Bird bird = new Bird();
        public Lizard lizard = new Lizard();
        
        public int Age
        {
            get { return bird.Age; }
            set
            {
                bird.Age = value;
                lizard.Age = value;
            }

        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }

        public override string ToString()
        {
            return $"Age: {Age} => {Fly()} +++ {Crawl()}";
        }
    }
}
