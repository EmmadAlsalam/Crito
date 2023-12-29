namespace ConsoleApp.Interfaces
{
    /// <summary>
    /// Gränssnitt för hantering av kundrelaterad.
    /// </summary>
    public interface ICustomerService
    {
        bool AddToList(string firstName, string lastName, string phoneNumber, string email, string address);
        IEnumerable<ICustomer> GetAllFromList();
        ICustomer? GetByEmail(string email);
        bool RemoveByEmail(string email);
        void SaveToFile();
        void LoadFromFile();
        bool AddToList(ICustomer customer);
    }
}
