using System;
using System.Collections.Generic;
using Plugin.Plugins;


namespace Plugin
{

    public class BasePluginWork<T>
    {
        public T ModificationData { get; set; }
        private Type plugType;
        public IPlugin CurrentPlugin { get; set; }
        private readonly string unsupported = "Sorry but this type is not suported in current version.";

        public BasePluginWork()
        {
            plugType = typeof(T);

            try
            {
                if (typeof (T) == typeof (double))
                    CurrentPlugin = new WithDouble();

                else if (typeof (T) == typeof (int))
                    CurrentPlugin = new WithInt();

                else if (typeof (T) == typeof (string))
                    CurrentPlugin = new WithString();
            }
            catch (Exception)
            {
                Console.WriteLine("Errow occured creatinf instance: BasePluginWork");
            }
        }

        public void DataOutput()
        {
            Console.WriteLine("Modified data by base class for plugins");
            try
            {
                if ((CurrentPlugin as IModify<T>) != null)
                    Console.WriteLine((CurrentPlugin as IModify<T>).Modify(ModificationData));
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t output data");
            }
           
             
        }
    }
}

