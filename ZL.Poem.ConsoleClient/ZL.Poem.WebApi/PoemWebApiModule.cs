using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ZL.Poem.Application;
using ZL.Poem.Core.Configuration;
using ZL.Poem.EF;

namespace ZL.Poem.WebApi
{
    [DependsOn(typeof(PoetDataModule),
       typeof(PoemApplicationModule),
        typeof(AbpAspNetCoreModule))]
    public class PoemWebApiModule:AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PoemWebApiModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);

        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString("DefaultConnection");
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //创建动态Web Api
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(PoemApplicationModule).Assembly, moduleName: "app", useConventionalHttpVerbs: false);

           // IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
           // //创建动态Web Api
           // Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(PoemApplicationModule).Assembly, moduleName: "app", useConventionalHttpVerbs: false);
           //// base.Initialize();
        }
    }
}
