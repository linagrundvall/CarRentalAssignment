using System;

namespace CarRental.Common.Interfaces
{
    public interface IBooking
    {
        int Id { get; }
        int VehicleId { get; }
        string RegistrationNumber { get; }
        IPerson Person { get; }
        DateTime Rented { get; }
        DateTime Returned { get; set; }
        double Cost { get; set; }
        double OdometerRented { get; }
        double OdometerReturned { get; set; }

        void ReturnVehicle(IVehicle vehicle);
    }
}
