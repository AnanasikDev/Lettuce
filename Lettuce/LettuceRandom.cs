using System;
using System.Collections.Generic;
using System.Linq;
namespace Lettuce
{
    // Random class
    public static class LettuceRandom
    {
        public static double NextGaussian(double min, double max, double hor_mean = 0, double std_deviation = 1)
        {
            double mean = ((max + min) / 2.0) + hor_mean;
            Random rand = new Random();
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1) * Math.Sin(2.0 * Math.PI * u2) + 16) - 4; 

            double randNormal = mean + std_deviation * randStdNormal;
            return randNormal;
        }
        public static double NextGaussian(this Random random, double hor_mean = 0, double stdDev = 1)
        {
            return NextGaussian(hor_mean, stdDev);
        }
        public static bool NextBool()
        {
            return new Random().Next(0, 1) == 0 ? false : true;
        }
        /// <summary>
        /// returns false/true = 1/ratio
        /// </summary>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public static bool NextBool(int ratio)
        {
            return new Random().Next(0, ratio) == 0 ? false : true;
        }
        public static T[] Shuffle<T>(this T[] collection)
        {
            T[] shuffled = collection;

            Random r = new Random();
            for (int i = 0; i < collection.Count(); i++)
            {
                int j = r.Next(0, i+1);
                T temp = collection[i];
                collection[i] = shuffled[j];
                shuffled[j] = temp;
            }
            return shuffled;
        }
    }
}
