using System;

namespace RandomAPI_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator gen = new Generator(100);

            for (int i = 0; i < 1000; i++)
                Console.WriteLine(gen.Enqueue());

            Console.ReadKey();
        }
    }
}
