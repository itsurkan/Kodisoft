using System;
using System.Collections.Generic;
using System.Reflection;
using Plugin.Plugins;


namespace Plugin
{
    public class BasePluginWork<T>
    {
        public T Data { get; set; }
        private Type plugType;
        public IPlugin CurrentPlugin { get; set; }
        protected readonly string unsupported = "Sorry but this type is not suported in current version.";

        public BasePluginWork()
        {
            plugType = typeof (T);
            CurrentPlugin = Factory.CreatePlugin(plugType);
        }
  
    public void DataOutput()
        {
            Console.WriteLine("Modified data by base class for plugins.  " + plugType.Name);
            try
            {
                if ((CurrentPlugin as IModify<T>) != null)
                    Console.WriteLine((CurrentPlugin as IModify<T>).Modify(Data));
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t output data");
            }
        }
    }
}

