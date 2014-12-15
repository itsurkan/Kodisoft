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
        protected abstract T Data { get; set; }
        public IPlugin<T> WithThisPlugin;
        public abstract void DataOutput();
        public abstract string GetPlugiNProp();
    }

    public class WorkWithString:BefourPlugin<string>
    {
        public WorkWithString()
        {
            WithThisPlugin = new WithString();
        }

        public override string GetPlugiNProp()
        {
            return WithThisPlugin.ToString();
        }

        public override void DataOutput()
        {
            Console.WriteLine(WithThisPlugin.Modify(Data).ToString());
        }

        protected override string Data {get { return "hallo my friend"; } set{}}}


    public class WorkWithDouble : BefourPlugin<double>
    {
        public WorkWithDouble()
        {
             WithThisPlugin = new WithDouble();
        }

        public override string GetPlugiNProp()
        {
            return  WithThisPlugin.ToString();
        }

        public override void DataOutput()
        {
           
            Console.WriteLine(WithThisPlugin.Modify(Data).ToString());
        }

        protected override double Data {get { return 8.95; }set { }}}


    public class WorkWithInt:BefourPlugin<int>
    {
        public WorkWithInt()
        {
            WithThisPlugin = new WithInt();
        }

        public override string GetPlugiNProp()
        {
            return WithThisPlugin.ToString();
        }

        public override void DataOutput()
        {
            Console.WriteLine(WithThisPlugin.Modify(Data).ToString());
        }

        protected override int Data { get { return 7; } set { } }
    }
    
}

