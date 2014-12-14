using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace References6
{


    class Program
    {
        public static Dictionary<Type,object> dictionary = new Dictionary<Type, object>();
        public static List<object> NewItem = new List<object>();

        static void Main(string[] args)
        {
            try
            {
                foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
                    if (assem.GetTypes()[0].GetConstructor(Type.EmptyTypes) != null)
                        dictionary.Add(assem.GetTypes()[0], assem.GetTypes()[0].GetConstructor(Type.EmptyTypes));
                
                foreach (var item in dictionary)
                {
                    NewItem.Add(Create(item.Key));
                    Console.WriteLine("Key = {0}", item.Key);
                    Console.WriteLine("Value = {0}", item.Value);
                    Console.WriteLine(NewItem.Last());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }
          
            //Console.ReadKey();
        }

        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
      

    }
}
