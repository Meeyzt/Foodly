using System;
using Foodly.Areas.Identity.Data;
using Foodly.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Foodly.Areas.Identity.IdentityHostingStartup))]
namespace Foodly.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserIdentityContextConnection")));

                services.AddDefaultIdentity<UserIdentity>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<UserIdentityContext>();
            });
        }
    }
}