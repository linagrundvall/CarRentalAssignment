using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<IBooking> _bookings = new List<IBooking>();

        public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(p => p.Id) + 1;
        public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(v => v.Id) + 1;
        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        public CollectionData()
        {
            SeedData();
        }

        private void SeedData()
        {
            _persons.Add(new Customer(1, "1234", "John", "Doe"));
            _persons.Add(new Customer(2, "5678", "Jane", "Doe"));

            _vehicles.AddRange(new List<IVehicle>
            {
                new Car(1, "Volvo", "ABC123", 10000, 1, VehicleStatuses.Available, VehicleTypes.Van),
                new Car(2, "Mazda", "DEF456", 20000, 1, VehicleStatuses.Available, VehicleTypes.Sedan),
                new Car(3, "Tesla", "GHI789", 1000, 3, VehicleStatuses.Available, VehicleTypes.Combi),
                new Motorcycle(4, "Yamaha", "JKL234", 6000, 1.5, VehicleStatuses.Available, VehicleTypes.Motorcycle),
                new Motorcycle(5, "Honda", "MNO567", 30000, 0.5, VehicleStatuses.Available, VehicleTypes.Motorcycle)
            });

            var vehicle1 = _vehicles.Single(v => v.Id.Equals(3));
            vehicle1.Status = VehicleStatuses.Booked;
            var person1 = _persons.Single(v => v.Id.Equals(1));
            _bookings.Add(new Booking(1, vehicle1, person1)); 

            var vehicle2 = _vehicles.Single(v => v.Id.Equals(4));
            var person2 = _persons.Single(v => v.Id.Equals(2));
            var booking = new Booking(2, vehicle2, person2);
            _bookings.Add(booking);
        }

        public IEnumerable<IPerson> GetPersons() => _persons;
        public IEnumerable<IBooking> GetBookings() => _bookings;
        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            if (status == default) return _vehicles;

            return _vehicles.Where(v => v.Status.Equals(status));
        }

        public IBooking GetBooking(int vehicleId)
        {
            var foundBooking = _bookings.Single(b => b.VehicleId.Equals(vehicleId));
            return foundBooking;
        }
                
        public IPerson GetPerson(string socialSecurityNumber)
        {
            var foundPerson = _persons.Single(p => p.SocialSecurityNumber.Equals(socialSecurityNumber));

            return foundPerson;
        }
        
        public IPerson GetPerson(int id)
        {
            var foundPerson = _persons.Single(p => p.Id.Equals(id));

            return foundPerson;
        }
        
        public IVehicle GetVehicle(string registrationNumber)
        {
            var foundVehicle = _vehicles.Single(v => v.RegistrationNumber.Equals(registrationNumber));

            return foundVehicle;
        }
        public IVehicle GetVehicle(int id)
        {
            var foundVehicle = _vehicles.Single(v => v.Id.Equals(id));

            return foundVehicle;
        }
       
        public void AddVehicle(IVehicle vehicle)
        {
            try
            {
                _vehicles.Add(new Vehicle(NextVehicleId, vehicle.Make, vehicle.RegistrationNumber, vehicle.Odometer, vehicle.CostKm, vehicle.Status, vehicle.Type));
            }
            catch
            {
                throw;
            }
        }
        
        public void AddPerson(IPerson customer)
        {
            try
            {
                _persons.Add(new Customer(NextPersonId, customer.SocialSecurityNumber, customer.FirstName, customer.LastName));
            }
            catch
            {
                throw;
            }
        }
        
        public void RentVehicle(int vehicleId, int customerId)
        {
            var vehicle = _vehicles.Single(v => v.Id.Equals(vehicleId));
            var customer = _persons.Single(c => c.Id.Equals(customerId));

            try
            {
                _bookings.Add(new Booking(NextBookingId, vehicle, customer));
            }
            catch
            {
                throw;
            }
        }

        public void ReturnVehicle(int vehicleId, double newOdometerValue)
        {
            //var booking = _bookings.Single(b => b.Id.Equals(vehicleId));
            var vehicle = _vehicles.Single(v => v.Id.Equals(vehicleId));

            try
            {               
                vehicle.UpdateOdometerValue(newOdometerValue);
            }
            catch
            {
                throw;
            }
        }
    }
}
