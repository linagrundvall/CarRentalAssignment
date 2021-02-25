using CarRental.Common.Interfaces;
using System;

namespace CarRental.Common.Classes
{
    public class Booking : IBooking 
    {
        public int Id { get; }
        public int VehicleId { get; }
        public string RegistrationNumber { get; }
        public IPerson Person { get; }
        public DateTime Rented { get; }
        public DateTime Returned { get; set; }
        public double Cost { get; set; }
        public double OdometerRented { get; }
        public double OdometerReturned { get; set; }

        public Booking(int id, IVehicle vehicle, IPerson person)
        {
            if (id < 0 || vehicle.Id < 0 || person == default)
                throw new AggregateException();

            Id = id;
            RegistrationNumber = vehicle.RegistrationNumber;
            VehicleId = vehicle.Id;
            Person = person;
            Rented = DateTime.Now;
            OdometerRented = vehicle.Odometer;
        }

        public void ReturnVehicle(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
