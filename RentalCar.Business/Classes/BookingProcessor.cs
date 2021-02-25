using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Classes;
using CarRental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db = new CollectionData();

        public IEnumerable<Customer> GetCustomers() => _db.GetPersons().Cast<Customer>();
        public IEnumerable<IBooking> GetBookings()
        {
            try
            {
                return _db.GetBookings();
            }
            catch
            {

                throw;
            }
        }
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            try
            {
                return _db.GetVehicles(status);
            }
            catch
            {

                throw;
            }
        }

        IBooking GetBooking(int vehicleId)
        {
            var foundBooking = _db.GetBooking(vehicleId);
            return foundBooking;
        }
        
        public Customer GetCustomer(int customerId)
        {
            var gottenCustomer = _db.GetPerson(customerId);
            Customer myCustomer = (Customer)gottenCustomer;
            
            return myCustomer;
        }
        
        public IVehicle GetVehicle(int vehicleId)
        {
            var gottenVehicle = _db.GetVehicle(vehicleId);
            return gottenVehicle;
        }
        
        public void AddVehicle(string make, string registrationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        {
            _db.AddVehicle(new Vehicle(_db.NextVehicleId, make, registrationNumber, odometer, costKm, status, type));
        }
        
        public void AddCustomer(string socialSecurityNumber, string firstName, string lastName)
        {
            _db.AddPerson(new Customer(_db.NextPersonId, socialSecurityNumber, firstName, lastName));
        
        }
                    
        public void RentVehicle(int vehicleId, int customerId)
        {
            _db.RentVehicle(vehicleId, customerId);

            var vehicle = _db.GetVehicle(vehicleId);
            vehicle.Status = VehicleStatuses.Booked;
        }

        public void ReturnVehicle(int vehicleId, double distance)
        {
            var vehicle = _db.GetVehicle(vehicleId);
            var booking = _db.GetBooking(vehicleId);

            double newOdometerValue = distance + vehicle.Odometer;
            _db.ReturnVehicle(vehicleId, newOdometerValue);

            booking.Returned = DateTime.Now;
                        
            var StartDate = booking.Rented;
            var EndDate = booking.Returned;
            var days = (EndDate - StartDate).TotalDays;
            if (days < 1)
                days = 1;
                        
            var cost = (days * vehicle.CostDay) + (distance * vehicle.CostKm);
            booking.Cost = cost;

            booking.OdometerReturned = distance + booking.OdometerRented;
                        
            vehicle.Status = VehicleStatuses.Available;
        }

        public string[] VehicleTypeNames => _db.VehicleTypeNames;
        public string[] VehicleStatusNames => _db.VehicleStatusNames;
        public VehicleStatuses GetVehicleStatus(string name) => _db.GetVehicleStatus(name);
        public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
    }
}
