using CarRental.Common.Classes;
using CarRental.Common.Interfaces;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;
using System.Linq;
using Xunit;

namespace CarRental.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void CanCreateCustomer()
        {
            IPerson customer = new Customer(1, "1234", "John", "Doe");

            Assert.Equal("Doe John (1234)", customer.ToString());
        }

        [Fact]
        public void CanReadCustomers()
        {
            IData data = new CollectionData();

            Assert.True(data.GetPersons().Count() > 0);
        }

        

    }
}
