using ConsoleApp.Interfaces;
using ConsoleApp.Services;

namespace ConsoleApp
{
    /// <summary>
    /// Huvudprogrammet som initierar applikationen.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Huvudsida för applikationen.
        /// </summary>
        /// <param name="args">Kommandoradens argument (ej använda här).</param>
        public void Main(string[] args)
        {
            // Skapa ett objekt av CustomerService för att hantera kunder
            ICustomerService customerService = new CustomerService();
            var menuServices = new MenuServices(customerService);

            // Kör ConsoleApp
            menuServices.Run();
        }
    }
}
