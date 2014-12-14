using System;
using System.Collections.Generic;
using System.Text;


namespace References6
{


    class Program
    {


        static void Main(string[] args)
        {
            var dictionary = new Dictionary<Type, object>();

            try
            {
                foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var temp = assem.GetTypes()[0].GetConstructor(Type.EmptyTypes);
                    if (temp != null)
                        dictionary.Add(assem.GetTypes()[0],temp);
                }
                foreach (var item in dictionary)
                {
                    var sb = new StringBuilder();
                    sb.AppendFormat("Key = {0}", item.Key);
                    sb.AppendLine();
                    sb.AppendFormat("Value = {0}", item.Value);
                    sb.AppendLine();
                    Console.WriteLine(sb);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Data);
            }

            Console.ReadKey();
        }



    }
}