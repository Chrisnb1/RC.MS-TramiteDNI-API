using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RC.MS_TramineDNI.Application.Services;
using RC.MS_TramiteDNI.AccessData;
using RC.MS_TramiteDNI.AccessData.Commands;
using RC.MS_TramiteDNI.AccessData.Queries;
using RC.MS_TramiteDNI.Domain.Commands;
using RC.MS_TramiteDNI.Domain.Queries;
using SqlKata.Compilers;

namespace RC.MS_TramiteDNI.API
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

            services.AddControllers();
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ApplicationDBContext>(opcion => opcion.UseSqlServer(connectionString));

            services.AddTransient<IGenericRepository, GenericRepository>();

            //Ignorar el bucle en el agregado de las listas.
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //SQLKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });
            services.AddTransient<IQuery, Query>();

            services.AddTransient<INuevoEjemplarServicio, NuevoEjemplarServicio>();
            services.AddTransient<IExtranjeroServicio, ExtranjeroServicio>();
            services.AddTransient<INacimientoServicio, NacimientoServicio>();
            services.AddTransient<ITramiteDNIServicio, TramiteDNIServicio>();

            //Cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Usar cors arriba de "Endpoins", sino no funciona.
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
