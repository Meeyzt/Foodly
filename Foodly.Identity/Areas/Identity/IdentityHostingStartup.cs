using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Foodly.Identity.Areas.Identity.IdentityHostingStartup))]
namespace Foodly.Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
               
            });
        }
    }
}