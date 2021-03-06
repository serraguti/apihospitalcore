using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHospital.Data;
using ApiHospital.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiHospital
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = this.Configuration.GetConnectionString("cadenahospitalazure");
            services.AddTransient<RepositoryHospital>();
            services.AddDbContext<HospitalContext>(options =>
            options.UseSqlServer(cadena));

            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc(name: "v2", new OpenApiInfo
                    {
                        Title = "Api Hospitales",
                         Version = "2.0", Description = "Api Hospitales Core 2021"
                    });
                });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint(
                        url: "/swagger/v2/swagger.json", name: "Api v2");
                    options.RoutePrefix = "";
                });
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
