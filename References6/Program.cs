using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace References6
{
    public class WorkwithDomains
    {
        public Dictionary<Type, object> Dictionary;

        public List<object> NewItem;

        private  object locker;

        public WorkwithDomains()
        {
            Dictionary = new Dictionary<Type, object>();
            NewItem = new List<object>();
            locker = new object();
        }

        public static object Create(Type type)
        {
                return Activator.CreateInstance(type);
        }

        public void DoOurWorkToTheEnd()
        {
            lock (locker)
            {
                try
                {
                    foreach (var assem in AppDomain.CurrentDomain.GetAssemblies())
                            if (assem.GetTypes()[0].GetConstructor(Type.EmptyTypes) != null)
                               lock(Dictionary) 
                                    Dictionary.Add(assem.GetTypes()[0], assem.GetTypes()[0].GetConstructor(Type.EmptyTypes));
                        

                    foreach (var item in Dictionary)
                    {
                        lock (NewItem)
                            NewItem.Add(Create(item.Key));
                            Console.WriteLine(NewItem.Last());

                            Console.WriteLine("Key = {0}", item.Key);
                            Console.WriteLine("Value = {0}", item.Value);
                            Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           WorkwithDomains domainsWorker = new WorkwithDomains();
           domainsWorker.DoOurWorkToTheEnd();
            //Console.ReadKey();
        }

       

    
    }
}