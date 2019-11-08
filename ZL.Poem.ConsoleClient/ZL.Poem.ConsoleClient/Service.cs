using System;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Castle.Windsor.Diagnostics.Extensions;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.ConsoleClient
{
    public class Service:ITransientDependency
    {
        public  void Run()
        {
            //Console.WriteLine("Hello World!");
            //获取poet的仓储
            var repPoets=IocManager.Instance.Resolve<IRepository<Poet>>();
            var poet= repPoets.FirstOrDefault(1);
           
               repPoets.InsertAsync(new Poet()
               {
                   Name = "张三",
                   Description = "hha"
               });
            Console.WriteLine(poet.Name);
            //.Logging.Abstractions
        }
    }
}