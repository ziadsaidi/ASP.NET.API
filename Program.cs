using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = BuildWebHost(args);
           using(var scope = host.Services.CreateScope())
        using(var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.EnsureCreated();
            }

            host.Run();

        }

        public static IHost BuildWebHost(string[] args) =>
           Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>{
                webBuilder.UseStartup<Startup>();
            })
            .Build();

       
    }
}
