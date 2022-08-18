using System;
using System.Text;
using System.IO;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MUIManagement.Application.Extensions;
using MUIManagement.Application.Services;
using MUIManagement.Infrastructure.Database;
using MUIManagement.WebApp.Configuration.JwtConfig;
using MUIManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace MUIManagement.WebApp
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MUIManagement.WebApp", Version = "v1" });
            });

            CreateDatabaseFolderIfNotExists(Configuration.GetConnectionString("DefaultConnection"));

            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });
            services.AddDefaultIdentity<IdentityUser>(opt =>
            opt.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddScoped<IRentalManagementRepository, RentalManagementRepository>();

            services.AddScoped<IUserManagementRepository, UserManagementRepository>();

            services.AddScoped<IMovieManagementRepository, MovieManagementRepository>();

            services.AddScoped<IAuthorManagementRepository, AuthorManagementRepository>();

            services.AddApplication();

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

            app.UseAuthentication();

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
