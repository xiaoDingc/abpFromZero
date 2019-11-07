using System;
using Abp;
using Abp.Dependency;


namespace ZL.Poem.ConsoleClient
{
    /// <summary>
    /// 学习链接 https://www.jianshu.com/p/effc0f61f273
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper=AbpBootstrapper.Create<PoemConsoleClientModule>())
            {
                //初始化模块
                bootstrapper.Initialize();
                //从容器中获取Service对象,并执行相应的函数
                var service=IocManager.Instance.Resolve<Service>();
                service.Run();

                Console.ReadKey();
            }
        }
    }
}
