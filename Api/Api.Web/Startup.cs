using Api.Domain;
using Api.MSsql;
using Api.Web.Helpers.OpenApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Reactions",
                    Version = "1.0.0"
                });

                options.OperationFilter<OperationIdFilter>();

                options.IncludeXmlComments(XmlPathProvider.XmlPath);
            });

            var connection = @"Server=DESKTOP-FQ83PKI;Database=Reactions;Trusted_Connection=True;";

            services.AddDbContext<MSsqlContext>(options =>
              options.UseSqlServer(
              connection, b => b.MigrationsAssembly(typeof(MSsqlContext).Assembly.FullName)));

            //For docker container db
            /*services.AddDbContext<MSsqlContext>(options => options
                .UseSqlServer(MssqlConnectionString(), b => b.MigrationsAssembly(typeof(MSsqlContext).Assembly.FullName)));
            */

            services.AddScoped<IUsersStorage, MSsqlUsersStorage>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IValidator<UsersContext>, UsersValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseSwagger()
                    .UseSwaggerUI(config => { config.SwaggerEndpoint("/swagger/v1/swagger.json", "Profiles Api V1"); });

                app.UseCors(builder => builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string MssqlConnectionString()
        {
            return $"Server={Configuration["MSSQL_ADDRESS"]},{Configuration["MSSQL_PORT"]};Database=Users;User={Configuration["MSSQL_USER"]};Password={Configuration["MSSQL_PASSWORD"]}";
        }
    }
}
