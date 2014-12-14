using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plugin
{
    public  class WithDouble: IPlugin<double>
    {
        public double Modify(double value)
        {
            return Math.Abs(value);
        }
    }


}
