using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lettuce
{
    // Random class
    public static class LettuceRandom
    {
        public static string debugPath = Directory.GetCurrentDirectory() + @"\debug.txt";
        public enum DebugType
        {
            console,
            file
        }
        public static double NextGaussian(double min = 0, double max = 1, double hor_mean = 0, double std_deviation = 1)
        {
            double mean = ((max + min) / 2.0) + hor_mean;
            Random rand = new Random();
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1) * Math.Sin(2.0 * Math.PI * u2) + 16) - 4;

            double randNormal = mean + std_deviation * randStdNormal;
            return randNormal;
        }
        public static double NextGaussian(this Random random, double min, double max, double hor_mean = 0, double stdDev = 1)
        {
            return NextGaussian(min, max, hor_mean, stdDev);
        }
        public static void NextGaussianDebug(int n, int m, DebugType debugType)
        {
            double[] ns = new double[n];
            for (int i = 0; i < n; i++)
            {
                ns[i] = LettuceRandom.NextGaussian();
            }
            int am = m;
            if (debugType == DebugType.console)
            {
                for (int _ = 0; _ < am; _++)
                {
                    int len = ns.Where(n => n < 1f / am * _ && n > 1f / am * (_ - 1)).ToArray().Length;
                    for (int i = 0; i < len; i++) Console.Write("*");
                    Console.WriteLine();
                }
            }
            else if (debugType == DebugType.file)
            {
                using (StreamWriter file = new StreamWriter(debugPath, false))
                {
                    for (int _ = 0; _ < am; _++)
                    {
                        int len = ns.Where(n => n < 1f / am * _ && n > 1f / am * (_ - 1)).ToArray().Length;

                        StringBuilder sb = new StringBuilder(len);
                        for (int i = 0; i < len; i++) sb.Append("*");
                        sb.Append("\n");

                        file.WriteLine(sb.ToString());
                    }
                }
            }
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
                int j = r.Next(0, i + 1);
                T temp = collection[i];
                collection[i] = shuffled[j];
                shuffled[j] = temp;
            }
            return shuffled;
        }
        public static int[] Unrepeatable(int min, int max, int step = 1)
        {
            int[] range = new int[(int)Math.Floor((decimal)(max - min) / step)];
            for (int i = 0; i < range.Length; i++) range[i] = min + step * i;
            return range.Shuffle();
        }
        public static float[] Unrepeatable(float min, float max, float step = 1)
        {
            float[] range = new float[(int)Math.Floor((max - min) / step)];
            for (int i = 0; i < range.Length; i++) range[i] = min + step * i;
            return range.Shuffle();
        }
    }
}