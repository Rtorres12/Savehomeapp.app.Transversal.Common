using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Savehomeapp.app.Transversal.Mapper;
using Savehomeapp.app.Transversal.Common;
using Savehomeapp.app.Infrastructure.Data;
using Savehomeapp.app.Infrastructure.Repository;
using Savehomeapp.app.Infrastructure.Interface;
using Savehomeapp.app.Domain.Interface;
using Savehomeapp.app.Domain.Core;
using Savehomeapp.app.Application.Main;
using Savehomeapp.app.Application.Interface;
using Microsoft.AspNetCore.HttpOverrides;

namespace Savehomeapp.app.Services.WebApi
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
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddScoped<IProductsDomain, ProductsDomain>();

            services.AddScoped<IProductsApplication, ProductsAplication>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Savehomeapp.app.Services.WebApi", Version = "v1" });
            });
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Savehomeapp.app.Services.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
