using System.Text.RegularExpressions;

namespace MasterMind
{
    public class Game
    {
        public static bool Start()
        {
            var checkGuess = new GuessChecker(GenerateSecret());
            Console.WriteLine($"{Environment.NewLine}Secret Code Generated. Start your guesses.");

            for (int i = 9; i >= 0; i--)
            {
                Console.Write($"{Environment.NewLine}Guesses Remaining {i + 1}: ");

                var guess = Console.ReadLine();
                bool isValidGuess = ValidateGuess(guess!, out int[] validGuess);
                if (isValidGuess)
                {
                    var isCorrect = GuessCheckerResult(checkGuess, validGuess);
                    if (isCorrect)
                        return true;
                }
                else
                {
                    Console.WriteLine("Not a valid number for a guess. Press any key to guess again.");
                    Console.ReadKey();
                }
            }
            return false;
        }

        public static int[] GenerateSecret()
        {
            var secret = new int[4];
            var random = new Random();
            while (secret.Distinct().Count() != 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    secret[i] = random.Next(1, 7);
                }
            }
            return secret;
        }
        public static bool ValidateGuess(string guess, out int[] validGuess)
        {
            validGuess = new int[4];
            bool isValidGuess = false;
            string pattern = "[1-6]{" + 4 + "}";
            if (guess.Length != 4) return false;

            var regEx = new Regex(pattern);
            if (regEx.IsMatch(guess))
            {
                for (int i = 0; i < 4; i++)
                {
                    validGuess[i] = (int)char.GetNumericValue(guess[i]);
                }
                isValidGuess = true;
            }
            return isValidGuess;
        }
        private static bool GuessCheckerResult(GuessChecker checkGuess, int[] guess)
        {
            var result = checkGuess.CheckGuess(guess);

            if (result.Equals("Right!"))
            {
                return true;
            }
            else
            {
                Console.WriteLine(result);
                return false;
            }
        }
    }
}
