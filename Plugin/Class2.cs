using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public class WithString:IPlugin<string>
    {
        private string _name;

        public string Name { get { return _name; } }

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
