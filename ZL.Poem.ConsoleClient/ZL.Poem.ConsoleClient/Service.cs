using System;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Castle.Windsor.Diagnostics.Extensions;
using ZL.Poem.Application.Poems;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.ConsoleClient
{
    public class Service:ITransientDependency
    {
        private  IPoetAppService _poetAppService;

        public Service(IPoetAppService poetAppService)
        {
            _poetAppService = poetAppService;
        }

        public  void Run()
        {
            ////Console.WriteLine("Hello World!");
            ////获取poet的仓储
            //var repPoets=IocManager.Instance.Resolve<IRepository<Poet>>();
            //var poet= repPoets.FirstOrDefault(1);

            //   repPoets.InsertAsync(new Poet()
            //   {
            //       Name = "张三",
            //       Description = "hha"
            //   });
            //Console.WriteLine(poet.Name);
            //.Logging.Abstractions
            #region 分页查询
            var res = _poetAppService.GetPagedPoets(dto: new PagedResultRequestDto()
            {
                MaxResultCount = 10,
                SkipCount = 1,
            }); 
            #endregion
            Console.WriteLine("TotalCount:"+res.TotalCount);
          foreach (var itemRes in res.Items)
          {
              Console.WriteLine(itemRes.Id+":"+itemRes.Name+":"+itemRes.Description);
          }
        }
    }
}