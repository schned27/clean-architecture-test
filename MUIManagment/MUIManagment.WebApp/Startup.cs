using System;
using System.IO;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MUIManagement.Infrastructure.Database;

namespace MUIManagement.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string AssemblyScope = "MUI";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MUIManagement.WebApp", Version = "v1" });
            });

            CreateDatabaseFolderIfNotExists(Configuration.GetConnectionString("DefaultConnection"));

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var modules = assemblies
                          .Where(x => x.ManifestModule.Name.StartsWith(AssemblyScope))
                          .ToArray();
            services.AddAutoMapper(modules);
            services.AddMediatR(modules);
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MUIManagement.WebApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void CreateDatabaseFolderIfNotExists(string connectionString)
        {
            string? marker = "DataSource=";
            // DataSource=Data/MaintenancePlanner.db            if (!connectionString.StartsWith(marker))            {                throw new ApplicationException("Invalid SQLite connection string");            }
            string? dataSource = connectionString.Replace(marker, "");
            if (File.Exists(dataSource)) { return; }
            string? folder = Path.GetDirectoryName(dataSource);
            if (string.IsNullOrEmpty(folder) || Directory.Exists(folder)) { return; }
            Directory.CreateDirectory(folder);
        }
    }
}
