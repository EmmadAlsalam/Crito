using ConsoleApp.Interfaces;

namespace ConsoleApp.Services
{
    /// <summary>
    /// Hanterar användargränssnittet och interaktion med kunder.
    /// </summary>
    public class MenuServices
    {
        private ICustomerService customerService;

        /// <summary>
        /// Skapar en ny instans av MenuServices.
        /// </summary>
        /// <param name="customerService">En instans av ICustomerService för att hantera kundrelaterade operationer.</param>
        public MenuServices(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        /// <summary>
        /// Huvudmetod för att köra användargränssnittet och interaktion med kunder.
        /// </summary>
        /// <param name="args">Kommandoradens argument (ej använda här).</param>
        public static void Main(string[] args)
        {
            // Skapa ett objekt av CustomerService för att hantera kunder
            ICustomerService customerService = new CustomerService();

            // Meny för att interagera med applikationen
            while (true)
            {
                Console.WriteLine("Välj en åtgärd:");
                Console.WriteLine("1. Lägg till kund");
                Console.WriteLine("2. Visa listan på alla kunder");
                Console.WriteLine("3. Visa detaljer om en kund");
                Console.WriteLine("4. Ta bort kund");
                Console.WriteLine("5. Avsluta och spara ");
                Console.WriteLine("-------------------------");




                Console.Write("Ange ditt val (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        // Lägg till kund
                        Console.Write("Ange förnamn: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Ange efternamn: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Ange telefonnummer: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Ange e-postadress: ");
                        string email = Console.ReadLine();
                        Console.Write("Ange adress: ");
                        string address = Console.ReadLine();

                        Console.WriteLine("Ny kund lagt i listan ");
                        Console.WriteLine("-------------------------");

                        customerService.AddToList(firstName, lastName, phoneNumber, email, address);
                        break;

                    case "2":
                        Console.Clear();

                        // Lista alla kunder
                        var allCustomers = customerService.GetAllFromList();
                        if (allCustomers.Any())
                        {
                            Console.WriteLine("Lista över alla kunder:");
                            foreach (var customer in allCustomers)
                            {
                                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
                                Console.WriteLine($"E-post: {customer.Email}");
                                Console.WriteLine("-------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Inga kunder hittades.");
                        }
                        break;


                    case "3":
                        Console.Clear();

                        // Visa detaljerad information om en kund
                        Console.Write("Ange e-postadress för att visa detaljer: ");
                        string emailToShow = Console.ReadLine();
                        var specificCustomer = customerService.GetByEmail(emailToShow);
                        if (specificCustomer != null)
                        {
                            Console.WriteLine($"Namn: {specificCustomer.FirstName} {specificCustomer.LastName}");
                            Console.WriteLine($"Telefonnummer: {specificCustomer.PhoneNumber}");
                            Console.WriteLine($"E-postadress: {specificCustomer.Email}");
                            Console.WriteLine($"Adress: {specificCustomer.Address}");




                            Console.WriteLine("-------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Kund ej hittad.");
                        }
                        break;

                    case "4":
                        Console.Clear();

                        // Ta bort en kund
                        Console.Write("Ange e-postadress för att ta bort: ");
                        string emailToRemove = Console.ReadLine();
                        bool removed = customerService.RemoveByEmail(emailToRemove);
                        if (removed)
                        {
                            Console.WriteLine("Kund borttagen.");

                            Console.WriteLine("-------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Kund ej hittad.");
                        }
                        break;

                    case "5":
                        // Avsluta programmet
                        Environment.Exit(0);
                        Console.WriteLine("Nu avslutar programet ");

                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        /// <summary>
        /// Kör användargränssnittet.
        /// </summary>
        internal void Run()
        {
            throw new NotImplementedException();
        }
    }
}