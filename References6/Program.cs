using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace References6
{


    class Program
    {


        static void Main(string[] args)
        {
            Dictionary<Type, object> dictionary = new Dictionary<Type, object>();

            Console.WindowWidth = 150;

            try
            {
                foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
                {
                    dictionary.Add(assem.GetTypes()[0], assem.GetName().Name);
                }
                foreach (var item in dictionary)
                {
                    StringBuilder sb = new StringBuilder();
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
