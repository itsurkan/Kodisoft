using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public  class WithInt:IPlugin<int>
    {
        private string _name;

        public string Name   { get { return _name; } }

        public WithInt()
        {
            _name = "Plugin for Ints";
        }

        public int Modify(int value)
        {
            if (value < 1)
            {
                return 0;
            }
            else
            {
                int res = 1;
                for (int i = 2; i < value; i++)
                {
                    res = res * value;
                }
                return res;
            }
        }
        public override string ToString()
        {
            return Name;
        }

       
    }


}
