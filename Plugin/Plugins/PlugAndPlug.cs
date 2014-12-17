using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Plugins
{
    public class PluginablePlugin : IPlugin, IModify<int>
    {
        private readonly string _name;


        public string GetName()
        {
            return "Pluginable Plugin";
        }

        public int Modify(int param)
        {
            int temp = param*2;
            WithInt ints = new WithInt();
            return ints.Modify(temp);
        }
    }


}
