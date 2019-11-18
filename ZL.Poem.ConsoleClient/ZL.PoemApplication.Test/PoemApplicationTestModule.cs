using System.Reflection;
using Abp.Modules;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZL.Poem.Application;
using ZL.Poem.EF;
using ZL.Poem.EF.EntityFramework;

namespace ZL.PoemApplication.Test
{
    [DependsOn(typeof(PoemApplicationModule),typeof(PoetDataModule),typeof(AbpTestBaseModule))]
    public class PoemApplicationTestModule:AbpModule
    {
        public PoemApplicationTestModule(PoetDataModule poetDataModule)
        {
            //跳过DbContext注册
            poetDataModule.SkipDbContextRegistration=true;
        }


        /// <summary>
        /// This is the first event called on application startup.
        /// Codes can be placed here to run before dependency injection registrations.
        /// </summary>
        public override void PreInitialize()
        {
            //EF Core InMemory DB does not support transactions.
            Configuration.UnitOfWork.IsTransactional=false;
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

        //private void SetupInMemoryDb()
        //{
        //    var services = new ServiceCollection()
        //        .AddEntityFrameworkInMemoryDatabase();

        //    var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
        //        IocManager.IocContainer,
        //        services
        //    );

        //    var builder = new DbContextOptionsBuilder<PoemGameDbContext>();
        //    builder.UseInMemoryDatabase().UseInternalServiceProvider(serviceProvider);
        //    IocManager.IocContainer.Register(
        //        Component
        //            .For<DbContextOptions<PoemGameDbContext>>()
        //            .Instance(builder.Options)
        //            .LifestyleSingleton()
        //    );
        //}
    }
}