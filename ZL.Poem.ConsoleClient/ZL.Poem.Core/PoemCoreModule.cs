using Abp.Modules;
using System;
using System.Reflection;
using Abp.Dependency;

namespace ZL.Poem.Core
{
    public class PoemCoreModule:AbpModule
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
