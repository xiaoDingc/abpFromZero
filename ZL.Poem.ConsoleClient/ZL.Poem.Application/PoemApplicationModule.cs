using System;
using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using ZL.Poem.Core;

namespace ZL.Poem.Application
{
    [DependsOn(typeof(PoemCoreModule),typeof(AbpAutoMapperModule))]
    public class PoemApplicationModule:AbpModule
    {
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
