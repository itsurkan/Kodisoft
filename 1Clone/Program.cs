using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace _1Clone
{
    public static class Func
    {
        public static T Clone<T>(this T toClone)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, toClone);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            int i = 5;
            int b;
            b = i.Clone();

            4.Clone();
            var str = "asdfasdf".Clone();
            var v = new object().Clone();

            Console.WriteLine(i);
            Console.WriteLine(b);

            Console.WriteLine(4.Clone());

            Console.WriteLine(str);
            Console.WriteLine(v);

            Console.ReadKey();

        }
    }
}
