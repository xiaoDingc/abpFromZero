using System.Reflection;
using Abp.Modules;

namespace ZL.Poem.ConsoleClient
{
    public class PoemConsoleClientModule:AbpModule
    {
        /// <summary>
        /// This method is used to register dependencies for this module.
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //base.Initialize();
        }
    }
}