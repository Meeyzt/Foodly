using Foodly.Identity.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Foodly.Identity.Areas.Identity.IdentityHostingStartup))]
namespace Foodly.Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserIdentityContextConnection")));

                services.AddDefaultIdentity<UserIdentity>(options => {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequiredLength = 8;
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789";
                })
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<UserIdentityContext>();

                services.AddDistributedMemoryCache();
            });
        }
    }
}