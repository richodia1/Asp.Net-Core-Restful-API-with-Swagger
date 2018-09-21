using LogicXPro.Domain;
using LogicXPro.Domain.Interfaces.DataAccess;
using LogicXPro.Domain.Interfaces.Managers;
using LogicXPro.Domain.Interfaces.Repositories;
using LogicXPro.Domain.Interfaces.Utilities;
using LogicXPro.Domain.Managers;
using LogicXPro.Infrastructure;
using LogicXPro.Infrastructure.Repositories;
using LogicXPro.utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LogicXPro
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

            services.AddMvc();
            // Add framework services.
            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EntityContext>(options =>
            {
                options.UseSqlServer(connection, b => b.MigrationsAssembly("LogicXPro"));
            });

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);

            //Configure dependency Injecttion
            ConfigureAppDependency(services);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "LogicXPro API",
                    Version = "v1"
                });
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug(LogLevel.Information);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseWebApiExceptionHandler();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "LogicXPro API");
            });

            //app.UseWelcomePage();
        }

        private static void ConfigureAppDependency(IServiceCollection services)
        {
            services.AddScoped<DbContext, EntityContext>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICoffeeManager, CoffeeManager>();
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
            services.AddTransient<IEmailNotification, EmailNotification>();
            services.AddTransient<IEncryption, MD5Encrpytion>();
            services.AddTransient<ILoggerRepository, LoggerRepository>();
        }
    }
}

