using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin3
{
    public static class WithInt
    {
        public static double Factorial(double value)
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
