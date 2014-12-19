using System;

namespace Plugin
{
    class Program
    {
        static void Main()
        {
            
            PluginContainer conteiners = new PluginContainer();
            conteiners.Modify("");
            Console.WriteLine();

            BasePluginWork<int> plugin = new BasePluginWork<int>();
            plugin.Data = 5;

            BasePluginWork<double> plugin1 = new BasePluginWork<double>();
            plugin1.Data = -65;

            BasePluginWork<string> plugin2 = new BasePluginWork<string>();
            plugin2.Data = "It is my life";
           
            plugin.DataOutput();
            plugin1.DataOutput();
            plugin2.DataOutput();
            Console.ReadKey();
        }
    }
}
