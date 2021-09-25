using System;
using System.Collections.Generic;

namespace DesignPatternsUdemy.ChainOfResponsibility
{
    public class Exercise
    {
        public static void Demo()
        {
            var game = new Game();
            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new Goblin(game));
            game.Creatures.Add(new GoblinKing(game));
            game.Creatures.Add(new Goblin(game));

            foreach (var creature in game.Creatures)
            {
                Console.WriteLine($"{creature.GetType()}: Attack={creature.Attack}, Defense={creature.Defense}");
            }
        }
    }

    public abstract class Creature
    {
        public int Attack { get; set; }
        public int Defense { get; set; }

    }

    public class Goblin : Creature
    {
        public Goblin(Game game)
        {
            Attack = 1;
            Defense = 1;

            foreach (var creature in game.Creatures)
            {
                if (creature is Goblin)
                {
                    creature.Defense += 1;
                }
            }
        }
    }

    public class GoblinKing : Goblin
    {
        public GoblinKing(Game game) : base(game)
        {
            Attack = 3;
            Defense = 3;

            foreach (var creature in game.Creatures)
            {
                if(creature is Goblin)
                {
                    creature.Attack += 1;
                }
            }
        }
    }

    public class Game
    {
        public IList<Creature> Creatures;

        public Game()
        {
            Creatures = new List<Creature>();
        }
    }
}
