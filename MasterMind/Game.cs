using System.Text.RegularExpressions;

namespace MasterMind
{
    public static class Game
    {
        /// <summary>
        /// Main game method that generates the secret code and checks each user guess to the secret code.
        /// </summary>
        /// <returns>True if user guesses correctly, false if all 10 guesses were incorrect.</returns>
        public static bool Start()
        {
            var checkGuess = new GuessChecker(GenerateSecret());
            Console.WriteLine(Environment.NewLine + "Secret Code Generated. Start your guesses.");

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

        /// <summary>
        /// Generate the secret code
        /// </summary>
        /// <returns>4 digit array with distinct values between 1 and 6</returns>
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

        /// <summary>
        /// Validates the user input a 4 digit number and then uses a regular expression pattern to
        /// check that the string is a number and is between 1 and 6.
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="validGuess"></param>
        /// <returns>True if guess is a valid number, otherwise false</returns>
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

        /// <summary>
        /// Compares user guess to the secret
        /// </summary>
        /// <param name="checkGuess"></param>
        /// <param name="guess"></param>
        /// <returns>True if guess matches secret code, otherwise false (will also print +/- combination when guessed incorrectly)</returns>
        private static bool GuessCheckerResult(GuessChecker checkGuess, int[] guess)
        {
            var result = checkGuess.CheckGuess(guess);

            if (result.Equals("++++"))
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
