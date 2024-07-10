using CashingNewProject.Model;
using Microsoft.Extensions.Caching.Memory;

namespace CashingNewProject.Services
{
    public class VehicleService : IVehicleService
    {
        public IMemoryCache _memoryCash;
        public string CashKey = "VehicleKey";

        public VehicleService(IMemoryCache memoryCash)
        {
            _memoryCash = memoryCash;
        }



        public List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicle;

            if(!_memoryCash.TryGetValue(CashKey, out vehicle))
            { 
                vehicle=GetVehiclesAsync().Result;
                _memoryCash.Set(CashKey, vehicle,TimeSpan.FromSeconds(30));
            }

            return vehicle;
        }






        private Task<List<Vehicle>> GetVehiclesAsync()
        {
            List<Vehicle> vehicle = new List<Vehicle>()
            {
                new Vehicle {Id=1,Name="Sulton"},
                new Vehicle {Id=2,Name="Malik"},
                new Vehicle {Id=3,Name="Karim"}
            };


            Task<List<Vehicle>> VehicleTask = Task<List<Vehicle>>.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return vehicle;
            });


            return VehicleTask;

        }






    }
}
