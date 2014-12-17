using System;

namespace Plugin
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginContainer list = new PluginContainer();
            list.Modify("");
            Console.WriteLine();

            BasePluginWork<int> basePlugin = new BasePluginWork<int>();
            basePlugin.Data = 5;
            basePlugin.DataOutput();
            
            //Console.ReadKey();
        }
    }
}
