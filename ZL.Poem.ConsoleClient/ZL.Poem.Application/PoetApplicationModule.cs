using System;
using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using ZL.Poem.Application.Poems;
using ZL.Poem.Core;

namespace ZL.Poem.Application
{
    [DependsOn(typeof(PoemCoreModule),typeof(AbpAutoMapperModule))]
    public class PoetApplicationModule:AbpModule
    {
        /// <summary>
        /// This is the first event called on application startup.
        /// Codes can be placed here to run before dependency injection registrations.
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config=>
            {
                config.CreateMap<Core.Poems.Poem,PoemDto>().ForMember(x=>x.AuthorName,opt=>
                    opt.MapFrom(x=>x.Author.Name));
            });
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
