using System;

namespace MasterMind
{
    public static class SecretGenerator
    {
        public static int[] GenerateSecret()
        {
            var secret = new int[4];
            var random = new Random();
            while (secret.Distinct().Count() != 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    secret[i] = random.Next(1,7);
                }
            }
            return secret;
        }
    }
}
