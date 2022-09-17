using Chat.Server.Extentions;
using Chat.Server.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCorsSettings()
                .AddSignalRSettings()
                .AddSingleton()
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJWTAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddApplicationServices()
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseCorsSettings()
                .UseDeveloperExceptionPage()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseAuthentication()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<ChatHub>("/chat");
                    endpoints.MapControllers();

                });
        }
    }
}
