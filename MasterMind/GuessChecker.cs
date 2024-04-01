namespace MasterMind
{
    public class GuessChecker(int[] answer)
    {
        private readonly int[] secret = answer;

        /// <summary>
        /// Compares each digit of the guess to that of the secret code.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns>A combination of +/- to represent correct digits and positions. ++++ means the guess was correct.</returns>
        public string CheckGuess(int[] guess)
        {
            var positionCorrect = new string[4];
            var numberCorrect = new string[4];

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    positionCorrect[i] = "+";
                }
                else
                {
                    if (secret.Contains(guess[i]))
                    {
                        numberCorrect[i] = "-";
                    }
                }
            }

            return string.Concat(positionCorrect.Concat(numberCorrect));
        }
    }
}
