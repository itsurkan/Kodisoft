using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


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

    public abstract  class BeforePlugin<T>
    {
        public string PluginProp { get;  set; }
        public abstract T Data { get; set; }
        public IPlugin<T> CurrentPlugin;
        public abstract void DataOutput();
        public abstract string GetPlugiNameProp();
    }

    public class WorkWithString:BeforePlugin<string>
    {
        public WorkWithString()
        {
            CurrentPlugin = new WithString();
        }

        public override string GetPlugiNameProp()
        {
            return CurrentPlugin.ToString();
        }

        public override void DataOutput()
        {
            Console.WriteLine(CurrentPlugin.Modify(Data).ToString());
        }

        public override string Data { get { return "hallo my friend"; } set { } }
    }


    public class WorkWithDouble : BeforePlugin<double>
    {
        public WorkWithDouble()
        {
             CurrentPlugin = new WithDouble();
        }

        public override string GetPlugiNameProp()
        {
            return  CurrentPlugin.ToString();
        }

        public override void DataOutput()
        {
           
            Console.WriteLine(CurrentPlugin.Modify(Data).ToString());
        }

        public  override double Data {get { return 8.95; }set { }}}


    public class WorkWithInt:BeforePlugin<int>
    {
        private int _data ;
        public override int Data { get { return _data; } set { _data = value; } }
        public WorkWithInt()
        {
            _data = 1;
            CurrentPlugin = new WithInt();
        }

        public override string GetPlugiNameProp()
        {
            return CurrentPlugin.ToString();
        }

        public override void DataOutput()
        {
            Console.WriteLine(CurrentPlugin.Modify(Data));
        }

       
    }

    public class GeneralModifyInt: BeforePlugin<int>, IPlugin<int>
    {
        private string _name;
        private int _data;

        public string Name {get { return _name; } set { }}
        public WorkWithInt CurrentWorker;
        public override int Data { get { return _data; } set { _data = value; } }

        public GeneralModifyInt()
        {
            _data = 2;
            _name = "Plugin and Pluginable for ints";
            CurrentWorker = new WorkWithInt();
            CurrentPlugin = new WithInt();
        }
        
        public int Modify(int param)
        {
            return Data * param;
        }
        
        public override void DataOutput()
        {
            Data = Modify(3);
            Console.WriteLine( CurrentPlugin.Modify(Data));
        }

        public override string GetPlugiNameProp()
        {
            return CurrentPlugin.ToString();
        }
    }
    
}

