using Contracts.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository.Context;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TemplateApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string CorsPolicyName = "CORS_POLICY";



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(AuthorizationFilterAttribute));
            });

            ConfigureSwaggerUi(services);

            services.AddCors(opt =>
            {
                opt.AddPolicy(CorsPolicyName,
                    builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            var connection_string = Configuration["ConnectionString:Default"];

            services.AddDbContext<TemplateDbContext>(options => options.UseSqlServer(connection_string));
            services.AddAutoMapper(typeof(Startup));

            var key = Encoding.ASCII.GetBytes(Configuration["Settings:JwtSecret"]);

            services.AddAuthentication(authOpt =>
            {
                authOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOpt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOpt =>
            {
                jwtOpt.RequireHttpsMetadata = false;
                jwtOpt.SaveToken = true;
                jwtOpt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            ConfigureDependencyInjection(services);

            services.AddGlobalExceptionHandlerMiddleware();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("*");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API v1");
                c.RoutePrefix = "";
            });

            app.UseGlobalExceptionHandlerMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureSwaggerUi(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Template.API Env: " + Configuration["EnviromentName"],
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insira o token JWT no campo abaixo. Ex: Bearer xxxyyyyzzz",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
            });
        }
        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            var _servicesAssembly = Assembly.Load("Business");
            var _contractsAssembly = Assembly.Load("Contracts");
            var _repositoriesAssembly = Assembly.Load("Repository");

            var _allServices = _servicesAssembly.GetTypes().Where(s => s.Namespace != null && s.Namespace.Contains("Business.Services") && s.Name.Contains("Service"));
            var _allServiceContracts = _contractsAssembly.GetTypes().Where(sc => sc.Namespace != null && sc.Namespace.Contains("Contracts.Interfaces.Services") && sc.IsInterface);

            var _allRepositories = _repositoriesAssembly.GetTypes().Where(r => r.Namespace != null && r.Namespace.Contains("Repository.Repositories") && r.Name.Contains("Repository"));
            var _allRepositoriyContracts = _contractsAssembly.GetTypes().Where(rc => rc.Namespace != null && rc.Namespace.Contains("Contracts.Interfaces.Repositories") && rc.IsInterface);

            //Services
            foreach (var service in _allServices)
            {
                var contract = _allServiceContracts.FirstOrDefault(c => c.Name.Contains(service.Name));

                if (contract != null && contract.IsInterface)
                    services.AddScoped(contract, service);
            }

            //Repositories
            foreach (var repository in _allRepositories)
            {
                var contract = _allRepositoriyContracts.FirstOrDefault(c => c.Name.Contains(repository.Name));

                if (contract != null)
                    services.AddScoped(contract, repository);
            }
        }
    }
}
