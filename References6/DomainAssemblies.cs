using System;
using System.Collections.Generic;
using System.Reflection;

namespace References6
{
    public class DomainAssemblies
    {
        private object locker;

        public Dictionary<Type, ConstructorInfo> Dictionary;

        public DomainAssemblies()
        {
            Dictionary = new Dictionary<Type, ConstructorInfo>();
            locker = new object();
        }

        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public void FindReferences()
        {
            lock (locker)
            {
                try
                {
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        var type = assembly.GetTypes()[0];
                        if (type.GetConstructor(Type.EmptyTypes) != null)
                            lock (Dictionary)
                                if (!Dictionary.ContainsKey(type))
                                    Dictionary.Add(type, type.GetConstructor(Type.EmptyTypes));
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void PrintRef()
        {
            foreach (var item in Dictionary)
            {
                lock (Dictionary)
                    Console.WriteLine("Key = {0}", item.Key);
                    Console.WriteLine("Value = {0}", item.Value);
                    Console.WriteLine();
            }
        }
    }
}