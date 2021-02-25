using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;
using System.Linq;
using Xunit;

namespace CarRental.Tests
{
    public class CommonTests
    {
        [Fact]
        public void CanCreateCar()
        {
            IVehicle car = new Car(1, "Mazda", "123ABC", 100, 1, VehicleStatuses.Available, VehicleTypes.Combi);

            Assert.Equal("123ABC", car.RegistrationNumber);
        }

        [Fact]
        public void CanCreateMotorcycle()
        {
            IVehicle motorcycle = new Motorcycle(2, "Honda", "456DEF", 200, 2, VehicleStatuses.Booked, VehicleTypes.Motorcycle);

            Assert.Equal("456DEF", motorcycle.RegistrationNumber);
        }

        [Fact]
        public void CanCreateBooking()
        {
            IVehicle motorcycle = new Motorcycle(1, "Honda", "456DEF", 200, 2, VehicleStatuses.Booked, VehicleTypes.Motorcycle);
            IPerson customer = new Customer(1, "1234", "John", "Doe");
            IBooking booking = new Booking(1, motorcycle, customer);

            Assert.Equal(1, booking.Id);
        }

        [Fact]
        public void CanGetBookings()
        {
            IData data = new CollectionData();

            Assert.True(data.GetBookings().Count() > 0);
        }

        [Fact]
        public void CanGetAllVehicles()
        {
            IData data = new CollectionData();

            Assert.True(data.GetVehicles().Count() > 0);
        }

        [Fact]
        public void CanGetVehicleByStatus()
        {
            IData data = new CollectionData();

            Assert.True(data.GetVehicles(VehicleStatuses.Booked).Count() > 0);
        }
    }
}
