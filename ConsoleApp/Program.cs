using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConsoleApp.Interfaces;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        public void Main(string[] args)
        {
           
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ICustomerService, CustomerService>();
                    services.AddSingleton<MenuServices>();
                })
                .Build();

            // Hämta en instans av MenuServices från hosten
            var menuServices = host.Services.GetRequiredService<MenuServices>();

            // Kör ConsoleApp
            menuServices.Run();
        }
    }
}
