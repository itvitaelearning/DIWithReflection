using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OwnLogger.Business;
using OwnLogger.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OwnLogger.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceTypes = new List<Type>();
            const string servicesNamespace = "OwnLogger.Business";
            const string interfacesNamespace = "OwnLogger.Business.Interfaces";

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                serviceTypes.AddRange(assembly.GetTypes()
                    .Where(t => t.Namespace != null
                        && t.GetCustomAttribute(typeof(CompilerGeneratedAttribute), true) == null
                        && (t.Namespace == servicesNamespace || t.Namespace == interfacesNamespace)).ToList());
            }

            foreach (var intfc in serviceTypes)
            {
                if (intfc.IsInterface && intfc.Name != "Ilogger")
                {
                    var impl = serviceTypes.FirstOrDefault(c => c.IsClass && intfc.Name.Substring(1) == c.Name);
                    if (impl != null) 
                        services.AddScoped(intfc, impl);
                }
            }

            // Onderstaande zou door de bovenstaande moeten worden gemaakt.
            //services.AddScoped<ILogger, Logger>();
            //services.AddScoped<IMovieService, MovieService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OwnLogger.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OwnLogger.Api v1"));
            }

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
