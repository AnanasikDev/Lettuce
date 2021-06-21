using System;
using System.Linq;
namespace Lettuce
{
    class main
    {
        static void Main(string[] args)
        {
            Debug();
        }
        static void Debug()
        {
            double[] ns = new double[100]; 
            for (int i = 0; i < 100; i++)
            {
                ns[i] = LettuceRandom.NextGaussian();
            }
            int am = 20;
            for (int _ = 0; _ < am; _++)
            {
                int len = ns.Where(n => n < 1f/am * _ && n > 1f/am * (_-1)).ToArray().Length;
                for (int i = 0; i < len; i++) Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}