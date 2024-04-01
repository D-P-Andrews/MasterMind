using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    public class GuessChecker(int[] answer)
    {
        private readonly int[] secret = answer;

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

            return guess.SequenceEqual(secret) ? "Right!" : string.Concat(positionCorrect.Concat(numberCorrect));
        }
    }
}
