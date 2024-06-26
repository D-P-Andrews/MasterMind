﻿namespace MasterMind
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Time to play MasterMind.");

            bool winner = Game.Start();

            if (winner)
            {
                Console.WriteLine(Environment.NewLine + "Congrats! You got the secret code! Press any key to quit.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Sorry, you didn't guess the secret code in 10 guesses. Press any key to quit.");
                Console.ReadKey();
            }
        }
    }
}