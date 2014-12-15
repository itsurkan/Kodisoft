using System;
using System.Collections.Generic;


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
       // public string PluginNameProp { get;  set; }
        public abstract T Data { get; set; }
        public IPlugin<T> CurrentPlugin;
        public abstract void DataOutput();
    }

    public class WorkWithString:BeforePlugin<string>
    {
        private WithString plugin;

        private string _data;

        public override string Data { get { return _data; } set { _data = value; } }

        public WorkWithString()
        {
            _data = "hallo my friend"; 
            CurrentPlugin = new WithString();
            plugin = CurrentPlugin as WithString;
        }

        public override void DataOutput()
        {
            Console.WriteLine(plugin.Name);
            Console.WriteLine(plugin.Modify(Data));
            Console.WriteLine();
        }
    }

    public class WorkWithDouble : BeforePlugin<double>
    {
        private WithDouble plugin;
            
        private double _data;

        public override double Data {get { return _data; } set { _data = value; }}

        public WorkWithDouble()
        {
            CurrentPlugin = new WithDouble();
            plugin = CurrentPlugin as WithDouble;
            _data = -15.9;
        }
        
        public override void DataOutput()
        {
            Console.WriteLine(plugin.Name);
            Console.WriteLine(plugin.Modify(Data));
            Console.WriteLine();
        }
    }

    public class WorkWithInt:BeforePlugin<int>
    {
        private WithInt plugin;

        private int _data ;

        public override int Data { get { return _data; } set { _data = value; } }

        public WorkWithInt()
        {
            CurrentPlugin = new WithInt();
            plugin = CurrentPlugin as WithInt;
            _data = 4;
        }

        public override void DataOutput()
        {
            Console.WriteLine(plugin.Name);
            Console.WriteLine(plugin.Modify(Data));
            Console.WriteLine();
        }

       
    }

    public class GeneralModifyInt: BeforePlugin<int>, IPlugin<int>
    {
        private readonly string _name;
        private int _data;
        private int _modofyData;
        private WithInt plugin;

        public string Name {get { return _name; } set { }}
        public WorkWithInt CurrentWorker;
        public override int Data { get { return _data; } set { _data = value; } }

        public int ModifyData { get { return _modofyData; } set { _modofyData = value; } }

        public GeneralModifyInt()
        {
            _name = "Plugin and Pluginable for ints";
            CurrentWorker = new WorkWithInt();
            CurrentPlugin = new WithInt();
            plugin = CurrentPlugin as WithInt;

            _modofyData = 3;
            _data = 4;
        }

        // modify method for plugit
        public int Modify(int param)
        {
            return  param*Data;
        }

        // method for moditified data output
        public override void DataOutput()
        {
            Data = Modify(_modofyData);

            Console.WriteLine(GetPlugiNameProp);
            Console.WriteLine(plugin.Modify(Data));
            Console.WriteLine();
        }

        public string GetPlugiNameProp { get {return "Plugin and Pluginable for ints"; } set{} }
    }
    
}

