using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace TemplateApiService.Common
{
    public class TemplateConfiguration
    {
        public string CurrentApiVersion { get; set; }


        //RedisDatabaseSettings
        public string RedisUrl { get; set; }
        public int RedisPort { get; set; }

        //OAuth Settings
        public string TemplateIssuer { get; set; }
        public string OAuthServerUrl { get; set; }
        public string OAuthSSClientId { get; set; }
        public string OAuthSSClientSecret { get; set; }
        public string OAuthSSUserName { get; set; }
        public string OAuthSSPassword { get; set; }
        public string OAuthDSSClientId { get; set; }
        public string OAuthDSSClientSecret { get; set; }
        public string OAuthRealm { get; set; }
        public string TemplatePublicKeyIssuer { get; set; }
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new TemplateConfiguration
            {
                RedisUrl = configuration.GetSection("RedisServerSettings").GetValue<string>("RedisUrl"),
                RedisPort = configuration.GetSection("RedisServerSettings").GetValue<int>("RedisPort"),
                CurrentApiVersion = configuration.GetSection("ProductSettings").GetValue<string>("CurrentApiVersion"),
                OAuthServerUrl = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthServerUrl"),
                OAuthSSClientId = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthSSClientId"),
                OAuthSSClientSecret = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthSSClientSecret"),
                OAuthSSUserName = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthSSUserName"),
                OAuthSSPassword = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthSSPassword"),
                OAuthDSSClientId = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthDSSClientId"),
                OAuthDSSClientSecret = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthDSSClientSecret"),
                OAuthRealm = configuration.GetSection("OAuthSettings").GetValue<string>("OAuthRealm") ?? "Template",
            });
        }
    }
}
