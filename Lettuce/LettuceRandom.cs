using System;

namespace Lettuce
{
    // Random class
    public static class LettuceRandom
    {
        public static double NextGaussian(double hor_mean = 0, double std_deviation = 1)
        {
            double max = 10;
            double min = 0;
            double mean = ((max + min) / 2.0) + hor_mean;
            Random rand = new Random();
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1) * Math.Sin(2.0 * Math.PI * u2) + 16) - 4;

            double randNormal = mean + std_deviation * randStdNormal;
            return Math.Round((double)randStdNormal, 5);
        }
        public static double NextGaussian(this Random random, double hor_mean = 0, double stdDev = 1)
        {
            return NextGaussian(hor_mean, stdDev);
        }
    }
}
