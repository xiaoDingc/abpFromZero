using System.Reflection;
using Abp.Modules;
using ZL.Poem.Core;
using ZL.Poem.EF;

namespace ZL.Poem.ConsoleClient
{
    [DependsOn(typeof(PoetDataModule),
        typeof(PoemCoreModule)
        )]
    public class PoemConsoleClientModule:AbpModule
    {
        /// <summary>
        /// This is the first event called on application startup.
        /// Codes can be placed here to run before dependency injection registrations.
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString="Server=localhost; Database=PoemNew; Trusted_Connection=True;";
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