using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Plugins
{
    public interface IPlugin
    {
        string GetName();
    }

    public interface IModify<T>
    {
        T Modify(T param);
    }
}
