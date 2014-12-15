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
            WorkWithInt temp = new WorkWithInt();
            temp.DataOutput();

            WorkWithDouble temp1 = new WorkWithDouble();
            temp1.DataOutput();

            WorkWithString temp2 = new WorkWithString();
            temp2.DataOutput();

          //  Console.ReadKey();
        }
    }
}
