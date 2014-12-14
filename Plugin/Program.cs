using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;
using Plugin1;
using Plugin2;
using Plugin3;

namespace Plugin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WithInt.Factorial(5));
            Console.WriteLine(WithDouble.Abs(-45.87));
            Console.WriteLine(WithString.removeSpaces("hallo my friend"));
            Console.ReadKey();
        }
    }
}
