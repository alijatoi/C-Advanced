using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    public interface IVehicle
    {
        void Drive(string content);
    }
   


    public class Car : IVehicle
    {
        public void Drive(string content)
        {
            Console.WriteLine("Car Driven " + content);
        }
    }



    public class VehicleUser
    {
        private readonly IVehicle _vehicle;
        public VehicleUser(IVehicle vehicle) // Dependency Injection via constructor
        {
            _vehicle = vehicle;
        }
        public void Drive(string content)
        {
            _vehicle.Drive(content);
        }
    }

}
