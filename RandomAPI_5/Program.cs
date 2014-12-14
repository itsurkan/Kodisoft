using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.random.JSONRPC;

namespace RandomAPI_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = 100;
            Console.WriteLine("Input max int number for sequence: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Queue<int> sequence = APISequenceGenerator(n);
            //Console.WriteLine(sequence.Count);
            Print(ref sequence);
            Console.ReadKey();
        }

        private static void Print(ref Queue<int> res)
        {
            int i = 0;
            while (res.Count() != 0)
            {
                Console.CursorLeft = 4 * (i % 10);
                Console.Write(res.Dequeue() + " ");

                if ((i != 0) && ((i + 1) % 10 == 0))
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop += 1;
                }
                i++;
            }
        }

        /// <summary>
        /// API Sequence Generator
        /// From Random.org
        /// </summary>
        public static Queue<int> APISequenceGenerator(int n)
        {
            const string apiKey = "8900240a-a7f2-433d-ad11-d3ca1987cc05";
            try
            {
                RandomJSONRPC client = new RandomJSONRPC(apiKey);
                Queue<int> res = new Queue<int>();
                int[] tmp = client.GenerateIntegers(n, 0, n);
                foreach (var num in tmp)
                {
                    res.Enqueue(num);
                }
                return res;
            }
            catch (Exception)
            {
                Console.WriteLine("API error");

                // Use BCL generator;
                return BCLSequenceGenerator(n);
            }
        }

        /// <summary>
        /// BCL Sequence Generator
        /// From Random.org
        /// </summary>
        public static Queue<int> BCLSequenceGenerator(int n)
        {
            Random rng = new Random();
            Queue<int> res = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                res.Enqueue(rng.Next(0, n));
            }
            return res;
        }

    }
}
