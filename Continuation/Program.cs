using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continuation
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var VARIABLE in args)
            {
                Console.WriteLine(VARIABLE);
            }
           
            Console.ReadKey();
        }
    }
}
