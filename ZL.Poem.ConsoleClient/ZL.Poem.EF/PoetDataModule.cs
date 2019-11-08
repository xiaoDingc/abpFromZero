using System.Reflection;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.EntityFrameworkCore;
using ZL.Poem.Core;
using ZL.Poem.EF.EntityFramework;

namespace ZL.Poem.EF
{
    [DependsOn(
        typeof(PoemCoreModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class PoetDataModule:AbpModule
    {
        /* 在单元测试时，使用EF Core的内存数据库，不需要进行数据库注册 */
        public bool SkipDbContextRegistration{get;set;}

        /// <summary>
        /// 初始化时注册DbContext
        /// This is the first event called on application startup.
        /// Codes can be placed here to run before dependency injection registrations.
        /// </summary>
        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                //配置模块如何连接数据库
                Configuration.Modules.AbpEfCore().AddDbContext<PoemGameDbContext>(options=>
                {
                    var builder=options.DbContextOptions;
                    if (options.ExistingConnection!=null)
                    {
                        builder.UseSqlServer(options.ExistingConnection);
                    }
                    else
                    {
                        builder.UseSqlServer(options.ConnectionString);
                    }
                });
            }
            base.PreInitialize();
        }

        /// <summary>
        /// This method is used to register dependencies for this module.
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            base.Initialize();
        }


    }
}