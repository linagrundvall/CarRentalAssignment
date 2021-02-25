using CarRental.Business.Classes;
using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using CarRental.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CarRental.Tests
{
    public class CollectionDataTests
    {
        [Fact]
        public void CanAddVehicle()
        {
            var data = new CollectionData();
            data.AddVehicle(new Vehicle(10, "Mazda", "HGJ345", 10000, 1, VehicleStatuses.Available, VehicleTypes.Combi));

            var foundcar = data.GetVehicle(10);

            Assert.Equal(10, foundcar.Id);
        }

        [Fact]
        public void CanAddVehicleToList()
        {
            var data = new BookingProcessor();
            data.AddVehicle("Mazda", "HGJ345", 10000, 1, VehicleStatuses.Available, VehicleTypes.Combi);
            var gottenVehicle = data.GetVehicle(6);

            Assert.Equal(6, gottenVehicle.Id);
        }
    }
}
