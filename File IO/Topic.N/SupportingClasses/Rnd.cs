using System;

namespace Topic.N.SupportingClasses
{
    public static class Rnd
    {
        private static Random Instance = new Random();

        public static int Next()
        {
            return Instance.Next();
        }
        public static int Next(int maxValue)
        {
            return Instance.Next(maxValue);
        }
        public static int Next(int minValue, int maxValue)
        {
            return Instance.Next(minValue, maxValue);
        }
        public static double NextDouble()
        {
            return Instance.NextDouble();
        }
    }
}
