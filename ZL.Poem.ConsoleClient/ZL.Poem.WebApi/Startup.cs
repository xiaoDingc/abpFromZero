using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ZL.Poem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           //config Cors
            services.AddCors(opt=>
            {
                opt.AddPolicy("cors",policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            });
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Poem API", Version = "v1" });
                c.DocInclusionPredicate((docName, description) => true);

                var baseUrl = AppDomain.CurrentDomain.BaseDirectory;
                var commentsFileName = @"ZL.Poem.Application.xml";
                var url = Path.Combine(baseUrl, commentsFileName);
                c.IncludeXmlComments(url);
            });
            #endregion
            return services.AddAbp<PoemWebApiModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {

            app.UseAbp();
            app.UseCors("cors");
             #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });

            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //使用静态文件
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
      
           
        }
    }
}
