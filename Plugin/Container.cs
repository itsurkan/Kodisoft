using System;
using System.Collections.Generic;
using Plugin.Plugins;


namespace Plugin
{

    public class PluginContainer : IPlugin, IModify<string>
    {
        private List<IPlugin> collection = new List<IPlugin>();

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
            collection.Add(PlugInt);
            collection.Add(PlugDouble);
            collection.Add(PlugString);
            collection.Add(PlugPliginable);
        }

        public string Modify(string param)
        {
            foreach (var plugin in collection)
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
                string name = plugin.GetName();
                switch (name)
                {
                    case "Plugin for doubles":
                        Console.WriteLine(plugin.GetName());
                        IModify<double> dPlug = plugin as IModify<double>;
                        double toOutput = dPlug.Modify(-89);
                        Console.WriteLine(toOutput.ToString());
                        Console.WriteLine();
                        break;

                    case "Plugin for Strings":

                        Console.WriteLine(plugin.GetName());
                        IModify<string> sPlug = plugin as IModify<string>;
                        string toOutputs = sPlug.Modify("THis is my life");
                        Console.WriteLine(toOutputs);
                        Console.WriteLine();
                        break;

                    case "Plugin for Ints":
                        Console.WriteLine(plugin.GetName());
                        IModify<int> iPlug = plugin as IModify<int>;
                        int toOutputi = iPlug.Modify(6);
                        Console.WriteLine(toOutputi);
                        Console.WriteLine();
                        break;

                    case "Pluginable Plugin":
                        Console.WriteLine(plugin.GetName());
                        IModify<int> pPlug = plugin as IModify<int>;
                        int toOutputp = pPlug.Modify(6);
                        Console.WriteLine(toOutputp);
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

