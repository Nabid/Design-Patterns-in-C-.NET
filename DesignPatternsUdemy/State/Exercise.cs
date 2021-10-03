using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternsUdemy.State
{
    public class Exercise
    {
        public static void Demo()
        {
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5});
            Console.WriteLine(cl.Status);

            for (int i = 1; i <= 5; i++)
            {
                cl.EnterDigit(i);
                Console.WriteLine(cl.Status);
            }
        }
    }

    public class CombinationLock
    {
        public CombinationLock(int[] combination)
        {
            Combination = string.Join("", combination.Select(x => x.ToString()));
            Status = LockStatus.LOCKED.ToString();
        }

        enum LockStatus
        {
            LOCKED,
            OPEN,
            ERROR
        }

        public string Combination;
        // you need to be changing this on user input
        public string Status;

        public void EnterDigit(int digit)
        {
            if (Status.Equals(LockStatus.LOCKED.ToString()))
            {
                Status = Convert.ToString(digit);
            }
            else
            {
                Status += Convert.ToString(digit);
            }
            
            if (Combination.Equals(Status))
            {
                Status = LockStatus.OPEN.ToString();
            }
            else if (!Combination.Substring(0, Status.Length).Equals(Status))
            {
                Status = LockStatus.ERROR.ToString();
            }
        }
    }
}
