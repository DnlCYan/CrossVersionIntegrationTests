using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4withRSA
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer(SetupIdentityServer)
                //.AddSigningCredential(IdentityServerBuilderExtensionsCrypto.CreateRsaSecurityKey())
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryApiScopes(Config.GetApiScopes())
                .AddInMemoryClients(Config.GetClients());

        }

        public static void SetupIdentityServer(IdentityServerOptions identityServerOptions)
        {
            identityServerOptions.AccessTokenJwtType = "JWT";
            identityServerOptions.EmitStaticAudienceClaim = true;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseIdentityServer();
        }
    }
}
