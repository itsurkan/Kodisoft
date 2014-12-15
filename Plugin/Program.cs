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

            WorkWithDouble temp1 = new WorkWithDouble();
            temp1.DataOutput();

            WorkWithString temp2 = new WorkWithString();
            temp2.DataOutput();

            WorkWithInt temp3 = new WorkWithInt();
            temp3.Data =4;
            temp3.DataOutput();

            GeneralModifyInt temp4 = new GeneralModifyInt();
            temp4.Data = 2;
            temp4.ModifyData = 3;
            temp4.DataOutput();

            Console.ReadKey();
        }
    }
}
