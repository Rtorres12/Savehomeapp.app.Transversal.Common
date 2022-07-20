using Exphadis.app.Application.Interface;
using Exphadis.app.Application.Main;
using Exphadis.app.Domain.Core;
using Exphadis.app.Domain.Interface;
using Exphadis.app.Infrastructure.Interface;
using Exphadis.app.Infrastructure.Repository;
using Exphadis.app.Services.WebApi.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Savehomeapp.app.Application.Interface;
using Savehomeapp.app.Application.Main;
using Savehomeapp.app.Domain.Core;
using Savehomeapp.app.Domain.Interface;
using Savehomeapp.app.Infrastructure.Data;
using Savehomeapp.app.Infrastructure.Interface;
using Savehomeapp.app.Infrastructure.Repository;
using Savehomeapp.app.Transversal.Common;
using Savehomeapp.app.Transversal.Mapper;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Savehomeapp.app.Services.WebApi
{
    public class Startup
    {
        readonly string myPolicy = "policySphadis";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(Configuration["Config:OriginCors"]).AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(origin => true).AllowCredentials().Build()));
            
            services.AddControllers();

            var appSettingSection = Configuration.GetSection("Config");
          
            services.Configure<AppSettings>(appSettingSection);

            var appSettings = appSettingSection.Get<AppSettings>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<ICoursesDomain, CoursesDomain>();
            services.AddScoped<ICoursesApplication, CoursesApplication>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserApplication, UserApplication>();

            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserLoginDomain, UserLoginDomain>();
            services.AddScoped<IUserLoginApplication, UserLoginApplication>();

            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped< ICategorieDomain, CategorieDomain >();
            services.AddScoped< ICategorieApplication, CategorieApplication>();

            services.AddScoped<ICourseBookingRepository, CourseBookingRepository>();
            services.AddScoped<ICourseBookingDomain, CourseBookingDomain>();
            services.AddScoped<ICourseBookingApplication, CourseBookingApplication>();

            services.AddScoped<IUserAdminLoginRepository, UserAdminLoginRepository>();
            services.AddScoped<IUserAdminLoginDomain, UserAdminLoginDomain>();

            services.AddScoped<IUserAdminDomain, UserAdminDomain>();
            services.AddScoped<IUserAdminApplication, UserAdminApplication>();
            services.AddScoped<IUserAdminRepository, UserAdminRepository>();


            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
               
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew =TimeSpan.Zero


                };
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exphadis.app.Services.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description="API KEY AUTHORIZATION",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type= SecuritySchemeType.ApiKey,
                    Scheme="Bearer"

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exphadis.app.Services.WebApi v1"));
            }
           
            app.UseRouting();
            app.UseCors(myPolicy);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
