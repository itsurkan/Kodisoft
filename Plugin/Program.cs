using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin;


namespace Plugin
{
    class Program
    {
        static void Main(string[] args)
        {
            WithInt temp = new WithInt();
            Console.WriteLine(temp.Modify(5));
            WithDouble temp1 = new WithDouble();
            Console.WriteLine(temp1.Modify(-45.87));
            WithString temp2 = new WithString();
            Console.WriteLine(temp2.Modify("hallo my friend"));
            Console.ReadKey();
        }
    }
}
