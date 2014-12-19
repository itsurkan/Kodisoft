using System;
using System.Collections.Generic;
using Plugin.Plugins;


namespace Plugin
{
    public class Factory
    {
        public static IPlugin CreatePlugin(Type plugType)
        {
            switch (plugType.Name)
            {
                case "Int32":
                    return new WithInt();

                case "Double":
                    return new WithDouble();

                case "String":
                    return new WithString();

                default:
                    Console.WriteLine("Unresolved type for PLugins. " + plugType);
                    break;
            }
            return null;
        }
    }
}

