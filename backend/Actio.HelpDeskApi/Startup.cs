using System;
using System.Reflection;
using Actio.HelpDeskApi.Context;
using Actio.HelpDeskApi.Repository;
using Actio.HelpDeskApi.Services;
using Actio.HelpDeskApi.Utils;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Actio.HelpDeskApi
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
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Actio.HelpDesk API", Version = "v1" });
            });

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<HelpDeskContext>(
                    options => options.UseSqlServer(
                        Configuration.GetConnectionString("ConexaoPadrao")));

            services.AddHttpContextAccessor();

            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();
            builder.RegisterType<BetService>().As<IBetService>();
            builder.RegisterType<BetRepository>().As<IBetRepository>();
            builder.RegisterType<ChartService>().As<IChartService>();

            builder.RegisterAssemblyTypes(typeof(RepositoryHelpDeskContext<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRepositoryHelpDeskContext<>));

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(option => option.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Actio.HelpDesk API V1");
            });
        }
    }
}
