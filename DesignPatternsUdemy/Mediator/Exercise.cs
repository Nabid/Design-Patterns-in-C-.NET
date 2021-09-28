using System;
using System.Collections.Generic;

namespace DesignPatternsUdemy.Mediator
{
    public class Exercise
    {
        public static void Demo()
        {
            var mediator = new Mediator();

            var jane = new Participant("jane", mediator);
            var alpha = new Participant("alpha", mediator);
            var beta = new Participant("beta", mediator);

            mediator.Join(jane);
            mediator.Join(alpha);
            mediator.Join(beta);
            mediator.PrintAll("Initial value");

            alpha.Say(3);
            mediator.PrintAll("alpha 3");
            //beta.Say(3);
            //mediator.PrintAll("beta 3");
            jane.Say(2);
            mediator.PrintAll("jane 2");
        }
    }

    public class Participant
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public Mediator Mediator { get; set; }

        public Participant(Mediator mediator)
        {
            this.Mediator = mediator;
        }

        public Participant(string name, Mediator mediator)
        {
            Name = name;
            Mediator = mediator;
        }

        public void Say(int n)
        {
            Mediator.Broadcast(this, n);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Value: {Value}";
        }
    }

    public class Mediator
    {
        public List<Participant> Participants = new List<Participant>();

        public void Join(Participant participant)
        {
            Participants.Add(participant);
        }

        public void Broadcast(Participant from, int value)
        {
            Participants.ForEach(p =>
            {
                if (p != from)
                {
                    p.Value += value;
                }
            });
        }

        public void PrintAll(string message = "")
        {
            Console.WriteLine(message);
            Participants.ForEach(p =>
            {
                Console.WriteLine(p);
            });
            Console.WriteLine("-------------------");
        }
    }

    /// SOLUTION
    //public class Participant
    //{
    //    private readonly Mediator mediator;
    //    public int Value { get; set; }

    //    public Participant(Mediator mediator)
    //    {
    //        this.mediator = mediator;
    //        mediator.Alert += Mediator_Alert;
    //    }

    //    private void Mediator_Alert(object sender, int e)
    //    {
    //        if (sender != this)
    //            Value += e;
    //    }

    //    public void Say(int n)
    //    {
    //        mediator.Broadcast(this, n);
    //    }
    //}

    //public class Mediator
    //{
    //    public void Broadcast(object sender, int n)
    //    {
    //        Alert?.Invoke(sender, n);
    //    }

    //    public event EventHandler<int> Alert;
    //}
}
