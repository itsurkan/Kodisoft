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
            plugin.DataOutput();
        }
    }
}
