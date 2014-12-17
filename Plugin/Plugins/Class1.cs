using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin.Plugins
{
    public class WithDouble : IPlugin, IModify<double>
    {
        private readonly string _name;

        public WithDouble()
        {
            _name = "Plugin for doubles";
        }

        public double Modify(double value)
        {
            return Math.Abs(value);
        }

        public string GetName()
        {
            return _name;
        }
    }


}
