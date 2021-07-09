using Calculator.Core;
using Calculator.Core.Service.Calculate;
using Calculator.Core.Services.Calculate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.WebAPI
{
    /// <summary>
    /// startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="configuration">configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 設定DI服務 This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">服務</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Calculator.WebAPI", Version = "v1" });
            });

            services.AddScoped<Core.Services.Calculate.CalculateFactory>();
        }

        /// <summary>
        /// Pipeline This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator.WebAPI v1"));
            }

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature?.Error is CalculateException)
                    {
                        var error = exceptionHandlerPathFeature?.Error as CalculateException;
                        context.Response.StatusCode = error.StatusCode;
                        var byteArr = Encoding.UTF8.GetBytes(error.Message);
                        MemoryStream st = new MemoryStream(byteArr);
                        context.Response.Body = st;
                    }
                    else
                    {
                        context.Response.StatusCode = 500;
                    }
                    
                });
            });
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
