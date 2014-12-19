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
            plugType= typeof(T);
            switch (plugType)
            {
                case typeof(double):
                    CurrentPlugin = new WithDouble();
                    break;

                case typeof(int):
                    CurrentPlugin = new WithInt();
                    break;

                case typeof(string):
                    CurrentPlugin = new WithString();
                    break;
                
                default:
                    CurrentPlugin = null;
                    Console.WriteLine("Unresolved type for PLugins. "+unsupported);
                    break;
            }
        }

        public void DataOutput()
        {
            Console.WriteLine("Modified data by base class for plugins");
            if(CurrentPlugin if IModify<T> && CurrentPlugin != null)
                Console.WriteLine(((CurrentPlugin)IModify<T>).Modify(ModificationData));
            else
                Console.WriteLine("Can`t output data. "+unsupported);
        }
    }
}

