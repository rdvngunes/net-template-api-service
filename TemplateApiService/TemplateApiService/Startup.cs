using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using TemplateApiService.BusinessObject.UsersBO;
using TemplateApiService.Common;
using TemplateApiService.Common.RedisDbClient;
using TemplateApiService.Common.RestClient;
using TemplateApiService.Common.Security;
using TemplateApiService.Common.SoraHttpClient;
using TemplateApiService.Data;
using TemplateApiService.Models.Users;
using System.Collections.Generic;
using TemplateApiService.Common.Converters;
using System.Text.Json.Serialization;

namespace TemplateApiService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string AllowSpecificOrigins = "AllowAllOrigins";

        public Startup(IWebHostEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                 .AddEnvironmentVariables();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            //Setting the serilog configuration
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(Configuration)
              .CreateLogger();

            Log.Information("Starting Template API Service...");
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            TemplateConfiguration.Configure(services, Configuration);
            var postgresConnectionString = Configuration.GetConnectionString("DefaultPostgreSqlConnection");
            var enableSensitiveDataLogging = Configuration.GetSection("ConnectionStrings").GetValue<bool>("EnableSensitiveDataLogging");
            string templateIssuer = Configuration.GetSection("OAuthSettings").GetValue<string>("TemplateIssuer");
            string TemplatePublicKeyIssuer = Configuration.GetSection("OAuthSettings").GetValue<string>("PublicKeyIssuer");

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(postgresConnectionString));
            services.AddHttpClient();

            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                 options.JsonSerializerOptions.IgnoreNullValues = true;
             });
            services.AddSwaggerGen();
            TypeConverter.Configure();

            // Adding JWT Token signature validation
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuers = new string[] { " " },//Need to add issuer
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuer = false, //Once issuer is added need to set to True
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKeys = new List<SecurityKey>
                        {
                            TokenValidation.GetPublicKey(TemplatePublicKeyIssuer)
                        }
                    };

                });

            services.AddHealthChecks()
              .AddNpgSql(postgresConnectionString, tags: new string[] { "PostgreSQL" });


            //Allow all origin cors ; after upgrade 3.0 it should be here.
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });


            AddCustomDependencies(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API Services");
            });

            app.UseRouting();
            app.UseCors(AllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(AllowSpecificOrigins);
            });
        }

        private void AddCustomDependencies(IServiceCollection services)
        {

            services.AddScoped<IDbRepository<User>, UserRepository>();
            services.AddScoped<IUsersBO, UsersBO>();

            services.AddSingleton<RedisDbClientHelper>();
            services.AddScoped<AuthorizationClaimsProvider>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<LanguageTranslationHelper>();
            services.AddScoped<ErrorResponseHelper>();

            services.AddSingleton<HttpClientHelper>();
            services.AddSingleton<HttpClientLogger>();
            services.AddSingleton<JwsHelper>();
        }
    }
}
