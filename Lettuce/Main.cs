using System;
using System.Linq;
namespace Lettuce
{
    class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LettuceRandom.debugPath);
            LettuceRandom.NextGaussianDebug(200, 200, LettuceRandom.DebugType.file);
        }
    }
}