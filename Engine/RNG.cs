using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class RNG
    {
        public static Random rng = new Random();

        public static int GenerateNumber(int minimumValue, int maximumValue)
        {
            return rng.Next(minimumValue, (maximumValue + 1));
        }
    }
}
