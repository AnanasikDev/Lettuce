using System;
using System.Linq;
namespace Lettuce
{
    class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", new int[5] { 1, 2, 3, 4, 5 }.Shuffle()));
        }
    }
}
