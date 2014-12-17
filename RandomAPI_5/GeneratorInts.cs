using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using org.random.JSONRPC;

namespace RandomAPI_5
{
    class Generator
    {
        private  Queue<int> localQ;
        private  int localQSize;

        public Generator(int limit)
        {
            localQSize = limit;
            localQ = new Queue<int>(localQSize);
        }

        public  int Enqueue()
        {
            try
            {
                if (localQ.Count == 0)
                {
                    Task loader = Task.Factory.StartNew(() => APISequenceGenerator(localQSize));
                    Task.WaitAll(loader);
                }
                return localQ.Dequeue();
            }
            catch (Exception)
            {
                Task.Factory.StartNew(() => BCLSequenceGenerator(localQSize));
                return localQ.Dequeue();
            }
        }

        /// <summary>
        /// API Sequence Generator. Not always the technical task
        /// Random.org
        /// </summary>
        private void APISequenceGenerator(int maxInt)
        {
            const string apiKey = "8900240a-a7f2-433d-ad11-d3ca1987cc05";
            try
            {
                RandomJSONRPC client = new RandomJSONRPC(apiKey);
                int[] tmp = client.GenerateIntegers(maxInt, 0, maxInt);

                foreach (var num in tmp)
                    localQ.Enqueue(num);
            }
            catch (Exception)
            {
                Console.WriteLine("API error");

                // Use BCL generator;
                BCLSequenceGenerator(maxInt);
            }
        }

        /// <summary>
        /// BCL Sequence Generator
        /// From Random.org
        /// </summary>
        private void BCLSequenceGenerator(int maxInt)
        {
            Random rng = new Random();

            for (int i = 0; i < maxInt; i++)
                localQ.Enqueue(rng.Next(0, maxInt));
        }

        public void PrintQueue()
        {
            int i = 0;
            while (localQ.Count() != 0)
            {
                Console.CursorLeft = 4 * (i % 10);
                Console.Write(localQ.Dequeue() + " ");

                if ((i != 0) && ((i + 1) % 10 == 0))
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop += 1;
                }
                i++;
            }
        }
    }
}
