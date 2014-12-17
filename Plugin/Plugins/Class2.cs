using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plugins
{
    public class WithString:IPlugin, IModify<string>
    {
        private readonly string _name;
        
        public string GetName()
        {
            return _name;
        }

        public WithString()
        {
            _name = "Plugin for Strings";
        }

        public  string Modify(string param)
        {
            return param.Replace(" ", "");
        }
    }
}
