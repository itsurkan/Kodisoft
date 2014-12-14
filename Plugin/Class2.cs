using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public static class WithString
    {
        public static string Modify(string param)
        {
            return param.ToLower();
        }

        public static string removeSpaces(string param)
        {
            return param.Replace(" ", "");
        }
    }
}
