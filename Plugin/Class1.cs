using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin
{
    public class WithDouble : IPlugin<double>
    {
        private string _name;

        public WithDouble()
        {
            this._name = "Plugin for doubles";
        }

        public double Modify(double value)
        {
            return Math.Abs(value);
        }

        public string Name
        {
            get { return _name; }
        }
    }


}
