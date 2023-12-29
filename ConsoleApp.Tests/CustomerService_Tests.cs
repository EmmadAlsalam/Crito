using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Xunit;


namespace ConsoleApp.Tests
{
    public class CustomerService_Tests
    {
        [Fact]
        public void AddToListShould_AddOneCustomerToCustomerList_ThenReturnTrue()
        {
            // Arrange
            ICustomer customer = new Customer
            {
                FirstName = "Emmad",
                LastName = "Alsalam",
                PhoneNumber = "123456789",
                Email = "emmad@example.com",
                Address = "Rullstenbacken"
            };
            ICustomerService customerService = new CustomerService();

            // Act 
            bool result = customerService.AddToList(customer);

            // Assert
            Assert.True(result);


        }

        [Fact]
        public void GetAllFromListShould_GetAllCustomersInCustomerList_ThenReturnListOfCustomer()
        {
            // Arrange
            ICustomerService customerService = new CustomerService();
            ICustomer customer = new Customer
            {
                FirstName = "Emmad",
                LastName = "Alsalam",
                PhoneNumber = "123456789",
                Email = "emmad@example.com",
                Address = "Rullstenbacken"
            };
            customerService.AddToList(customer);

            // Act
            IEnumerable<ICustomer> result = customerService.GetAllFromList();

            // Assert
            Assert.NotNull(result);
            Assert.True(((IEnumerable<Customer>)result).Any());

        }
    }
}
