using System;
using System.Collections.Generic;

namespace DesignPatternsUdemy.Factory
{
    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinFactory>> factories =
            new List<Tuple<string, IHotDrinFactory>>();
        /// <summary>
        /// Abstract factory
        /// </summary>
        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if(typeof(IHotDrinFactory).IsAssignableFrom(t) &&
                        !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinFactory)Activator.CreateInstance(t)
                    ));
                }
            }
        }

        public IHotDrink MakeDrink(int item, int amount)
        {
            Console.WriteLine("Available Drinks:");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                Console.WriteLine($"{i}: {tuple.Item1}");
            }

            return factories[item].Item2.Prepare(amount);
        }
    }

    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Nice Tea");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Nice Coffee");
        }
    }

    interface IHotDrinFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put teabag, boil water.... {amount} ml ... woila");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind bins, boil water.... {amount} ml ... woila");
            return new Coffee();
        }
    }

    public static class AbstractFactoryDemo
    {
        public static void Demo()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(1, 30);
        }
    }
}
