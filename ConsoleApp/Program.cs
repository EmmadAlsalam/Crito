using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Interfaces;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        public void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICustomerService, CustomerService>()
                .AddSingleton<MenuServices>()
                .BuildServiceProvider();

            // Hämta en instans av MenuServices från tjänsteförsettningen
            var menuServices = serviceProvider.GetRequiredService<MenuServices>();

            // Kör ConsoleApp
            menuServices.Run();
        }
    }
}
