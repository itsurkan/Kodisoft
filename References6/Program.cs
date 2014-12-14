using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;


namespace References6
{


    class Program
    {
        public static Dictionary<Type,object> dictionary = new Dictionary<Type, object>();

        static void Main(string[] args)
        {
            try
            {
                foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assem.GetTypes()[0].GetConstructor(Type.EmptyTypes) != null)
                        dictionary.Add(assem.GetTypes()[0], assem.GetTypes()[0].GetConstructor(Type.EmptyTypes));
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
                foreach (var item in dictionary)
                {
                    var obj = Create(item.Key);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Data);
            }
          
            //Console.ReadKey();
        }

        public static object Create(Type type)
        {
            var r =  dictionary[type].GetType();
            return r;
        }
      

    }
}
