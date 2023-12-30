using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;


namespace ConsoleApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customerList = new List<Customer>();
        private readonly string _filePath = @"c:\projects\Crito\Customer.json";

        public string FilePath => _filePath; // Korrigera FilePath-egenskapen

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

                SaveToFile();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid tillägg av kund: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<ICustomer> GetAllFromList()
        {
            try
            {
                LoadFromFile(); // Flytta laddningen av filen här

                return _customerList.Cast<ICustomer>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return Enumerable.Empty<ICustomer>();
            }
        }

        public ICustomer? GetByEmail(string email)
        {
            try
            {
                LoadFromFile();

                return _customerList.Find(c => c.Email == email);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool RemoveByEmail(string email)
        {
            try
            {
                LoadFromFile();

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

        public void SaveToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_customerList, Formatting.Indented);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparande till fil: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    _customerList.Clear();
                    _customerList.AddRange(JsonConvert.DeserializeObject<List<Customer>>(json));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid inläsning från fil: {ex.Message}");
            }
        }

        public bool AddToList(ICustomer customer)
        {
            try
            {
                LoadFromFile();

                customer.Id = _customerList.Count + 1;
                _customerList.Add((Customer)customer);
                SaveToFile();
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
