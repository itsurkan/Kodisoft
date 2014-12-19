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
                        Console.WriteLine((plugin as IModify<double>).Modify(-89).ToString());
                        Console.WriteLine();
                        break;

                    case "Plugin for Strings":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<string>).Modify("THis is my life"));
                        Console.WriteLine();
                        break;

                    case "Plugin for Ints":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<int>).Modify(6).ToString());
                        Console.WriteLine();
                        break;

                    case "Pluginable Plugin":
                        Console.WriteLine(pluginName);
                        Console.WriteLine((plugin as IModify<int>).Modify(6).ToString());
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

