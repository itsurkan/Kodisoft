using System;
using System.Collections.Generic;
using System.Reflection;

namespace References6
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainAssemblies domainsWorker = new DomainAssemblies();
            domainsWorker.FindReferences();
            domainsWorker.PrintRef();
            //Console.ReadKey();
        }
    }
}