using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;



namespace Plugin
{
    public interface IPlugin<T>
    {
       
       T Modify(T param);
    }

    public class PluginContainer : IPlugin<List<IPlugin<object>>>
    {
        private List<IPlugin<object>> collection = new List<IPlugin<object>>();

        
        public List<IPlugin<object>> Modify(List<IPlugin<object>> param)
        {
            collection.AddRange(param);
            return collection;
        }
    }

    public abstract  class BefourPlugin<T>
    {
        protected string PluginProp { get;  set; }
        protected T DataProp { get; set; }
        public IPlugin<T> with;
        protected void DataOutput(T data)
        {
            Console.WriteLine();
        }
     
        public abstract string GetPlugiNProp();
 
    }

    public class WorkWithString:BefourPlugin<string>
    {
        
        public override string GetPlugiNProp()
        {
            return null;
          
        }

    }
    public class WorkWithDouble : BefourPlugin<double>
    {
        public override string GetPlugiNProp()
        {
            return null;
        }
    }
    public class WorkWithInt:BefourPlugin<int>
    {
        public override string GetPlugiNProp()
        {
            return null;
        }
    }
    
}

