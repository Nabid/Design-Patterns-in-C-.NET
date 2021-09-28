using System;
namespace DesignPatternsUdemy.Command
{
    public class Exercise
    {
        public static void Demo()
        {
            var a = new Account();

            var command = new Command { Amount = 100, TheAction = Command.Action.Deposit };
            a.Process(command);

            //Assert.That(a.Balance, Is.EqualTo(100));
            //Assert.IsTrue(command.Success);

            command = new Command { Amount = 50, TheAction = Command.Action.Withdraw };
            a.Process(command);

            //Assert.That(a.Balance, Is.EqualTo(50));
            //Assert.IsTrue(command.Success);

            command = new Command { Amount = 150, TheAction = Command.Action.Withdraw };
            a.Process(command);

            //Assert.That(a.Balance, Is.EqualTo(50));
            //Assert.IsFalse(command.Success);
        }
    }

    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;

        //public Command(Action theAction, int amount, bool success)
        //{
        //    TheAction = theAction;
        //    Amount = amount;
        //    Success = success;
        //}
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Deposit(c.Amount);
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    c.Success = Withdraw(c.Amount);
                    break;
                default:
                    break;
            }
        }

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        public bool Withdraw(int amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
