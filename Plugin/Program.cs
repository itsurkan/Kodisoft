﻿using System;

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
            // temp3.Data =4;
            temp3.DataOutput();

            GeneralModifyInt temp4 = new GeneralModifyInt();
            temp4.Data = 2;
           // temp4.ModifyData = 4;
            temp4.DataOutput();

            Console.ReadKey();
        }
    }
}
