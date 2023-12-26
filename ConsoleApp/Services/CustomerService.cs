using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace ConsoleApp.Services
{
    /// <summary>
    /// Tjänst för hantering av kundinformation.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customerList = new List<Customer>();
        private const string FilePath = @"c:\Projects\Crito\contacts.json";

        /// <summary>
        /// Lägger till en ny kund i listan och sparar till filen.
        /// </summary>
        /// <param name="firstName">Förnamn på kunden.</param>
        /// <param name="lastName">Efternamn på kunden.</param>
        /// <param name="phoneNumber">Telefonnummer på kunden.</param>
        /// <param name="email">E-postadress på kunden.</param>
        /// <param name="address">Adress på kunden.</param>
        /// <returns>True om kunden läggs till framgångsrikt; annars false.</returns>
        public bool AddToList(string firstName, string lastName, string phoneNumber, string email, string address)
        {
            try
            {
                Customer customer = new Customer
                {
                    Id = _customerList.Count + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Address = address
                };

                _customerList.Add(customer);

                // Flytta SaveToFile och andra operationer här, efter att ha lagt till kunden
                SaveToFile();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid tillägg av kund: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Hämtar alla kunder från listan.
        /// </summary>
        /// <returns>En IEnumerable av ICustomer.</returns>
        public IEnumerable<ICustomer> GetAllFromList()
        {
            try
            {
                return _customerList.Cast<ICustomer>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Enumerable.Empty<ICustomer>();
            }
        }

        /// <summary>
        /// Hämtar en kund efter e-postadress.
        /// </summary>
        /// <param name="email">E-postadress på kunden.</param>
        /// <returns>Kunden med den angivna e-postadressen, eller null om den inte hittas.</returns>
        public ICustomer? GetByEmail(string email)
        {
            LoadFromFile();
            return _customerList.Find(c => c.Email == email);
        }

        /// <summary>
        /// Tar bort en kund efter e-postadress och sparar till filen.
        /// </summary>
        /// <param name="email">E-postadress på kunden som ska tas bort.</param>
        /// <returns>True om kunden tas bort framgångsrikt; annars false.</returns>
        public bool RemoveByEmail(string email)
        {
            try
            {
                Customer? customerToRemove = _customerList.Find(c => c.Email == email);
                if (customerToRemove != null)
                {
                    _customerList.Remove(customerToRemove);
                    SaveToFile();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid borttagning av kund: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Sparar kundlistan till en JSON-fil.
        /// </summary>
        public void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(_customerList, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        /// <summary>
        /// Läser in kunddata från JSON-filen.
        /// </summary>
        public void LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                _customerList.Clear();
                _customerList.AddRange(JsonConvert.DeserializeObject<List<Customer>>(json));
            }
        }

        /// <summary>
        /// Lägger till en kund i listan.
        /// </summary>
        /// <param name="customer">Kunden som ska läggas till.</param>
        /// <returns>True om kunden läggs till framgångsrikt; annars false.</returns>
        public bool AddToList(ICustomer customer)
        {
            try
            {
                customer.Id = _customerList.Count + 1;
                _customerList.Add((Customer)customer);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
