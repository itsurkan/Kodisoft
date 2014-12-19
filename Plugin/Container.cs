using System;
using System.Collections.Generic;
using Plugin.Plugins;


namespace Plugin
{

    public class PluginContainer : IPlugin, IModify<string>
    {
        private List<IPlugin> plugins = new List<IPlugin>();

        public string GetName()
        {
            return "Pluginable Plugin";
        }

        public PluginContainer()
        {
            IPlugin PlugInt = new WithInt();
            IPlugin PlugDouble = new WithDouble();
            IPlugin PlugString = new WithString();
            IPlugin PlugPliginable = new PluginablePlugin();
            plugins.Add(PlugInt);
            plugins.Add(PlugDouble);
            plugins.Add(PlugString);
            plugins.Add(PlugPliginable);
        }

        public string Modify(string param)
        {
            foreach (var plugin in plugins)
            {
                RunPlugin(plugin);
            }
            Console.WriteLine("PluginContainer: Work is done  "+param);
            return param;
        }

        private void RunPlugin(IPlugin plugin)
        {
            try
            {
                string pluginName = plugin.GetName();
                switch (pluginName)
                {
                    case "Plugin for doubles":
                        Console.WriteLine(pluginName);
                        IModify<double> plugDouble = plugin as IModify<double>;
                        Console.WriteLine(plugDouble.Modify(-89).ToString());
                        Console.WriteLine();
                        break;

                    case "Plugin for Strings":

                        Console.WriteLine(pluginName);
                        IModify<string> plugString = plugin as IModify<string>;
                        Console.WriteLine(plugString.Modify("THis is my life"));
                        Console.WriteLine();
                        break;

                    case "Plugin for Ints":
                        Console.WriteLine(pluginName);
                        IModify<int> plugInt = plugin as IModify<int>;
                        Console.WriteLine(plugInt.Modify(6).ToString());
                        Console.WriteLine();
                        break;

                    case "Pluginable Plugin":
                        Console.WriteLine(pluginName);
                        IModify<int>  plugPliginable = plugin as IModify<int>;
                        Console.WriteLine(plugPliginable.Modify(6).ToString());
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Error wher applied Plugins");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error wher applied Plugins");
            }
        }
        }

  
    
}

