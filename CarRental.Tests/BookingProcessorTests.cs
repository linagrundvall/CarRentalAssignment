using Xunit;
using System.Linq;
using CarRental.Business.Classes;

namespace CarRental.Tests
{
    public class BookingProcessorTests
    {
        [Fact]
        public void CanReadCustomers()
        {
            var bp = new BookingProcessor();
            Assert.True(bp.GetCustomers().Count() > 0);
        }

        [Fact]
        public void CanReadBookings()
        {
            var bp = new BookingProcessor();
            Assert.True(bp.GetBookings().Count() > 0);
        }

        [Fact]
        public void CanReadVehicles()
        {
            var bp = new BookingProcessor();
            Assert.True(bp.GetVehicles().Count() > 0);
        }
    }
}
