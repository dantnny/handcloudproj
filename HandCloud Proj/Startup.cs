using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandCloud_Proj.Data.Interfaces;
using HandCloud_Proj.Data.Repository;
using HandCloud_Proj.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HandCloud_Proj
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(
                options =>
                {
                    options.AddPolicy("AllowAnyOrigin",
                        builder =>
                        {
                            builder.AllowAnyHeader();
                            builder.AllowAnyMethod();
                            builder.AllowAnyOrigin();
                        });
                });
            
            

            services.AddScoped<IJSONContext>(s => new JSONContext(Configuration));
            services.AddScoped<ICarRepository, CarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
