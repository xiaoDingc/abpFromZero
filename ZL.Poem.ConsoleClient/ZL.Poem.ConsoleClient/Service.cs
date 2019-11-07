using System;
using Abp.Dependency;

namespace ZL.Poem.ConsoleClient
{
    public class Service:ITransientDependency
    {
        public  void Run()
        {
            Console.WriteLine("Hello World!");
        }
    }
}