using System;
using System.Collections.Generic;
using Plugin.Plugins;


namespace Plugin
{

    public class BasePluginWork<T>
    {
        public T Data { get; set; }
        private Type _typeProp { get; set; }
        public IPlugin CurrentPlugin;

        public BasePluginWork()
        {
            try
            {
                _typeProp = typeof(T);
                if (typeof(T) == typeof(double))
                    CurrentPlugin = new WithDouble();

                else if (typeof(T) == typeof(int))
                    CurrentPlugin = new WithInt();

                else if (typeof(T) == typeof(string))
                    CurrentPlugin = new WithString();
            }
            catch (Exception)
            {
                Console.WriteLine("Errow occured creatinf instance: BasePluginWork");
            }
          
        }

        public void DataOutput()
        {
            try
            {
                Console.WriteLine("Modified data by base class for plugins");
                Console.WriteLine((CurrentPlugin as IModify<T>).Modify(Data));
            }
            catch (Exception)
            {
                Console.WriteLine("Can`t output data");
                throw;
            }
           
        }
    }
}

