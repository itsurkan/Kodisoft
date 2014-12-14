using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public  class WithInt:IPlugin<double>
    {
        public double Modify(double value)
        {
            if (value < 1)
            {
                return 0;
            }
            else
            {
                double res = 1;
                for (int i = 2; i < value; i++)
                {
                    res = res * value;
                }
                return res;
            }
        }
    }

}
