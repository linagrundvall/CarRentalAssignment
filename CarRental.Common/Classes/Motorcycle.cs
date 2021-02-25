using CarRental.Common.Enums;

namespace CarRental.Common.Classes
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(int id, string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        : base(id, make, registrationNumber, odometer, costKm, status, type)
        {
        }
    }
}
