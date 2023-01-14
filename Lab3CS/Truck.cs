using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CS
{
    internal class Truck : ICarBrand {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
        public string MaximumSpeed { get; set; }
        public string RegistrationNumber { get; set; }
        public string NumberOfWheels { get; set; }
        public string BodyVolume { get; set; }

        public Truck(string brand, string model, string power, string maximumSpeed) {
            Brand = brand;
            Model = model;
            Power = power;
            MaximumSpeed = maximumSpeed;
        }

        public Truck(ICarBrand truck, string registrationNumber, string numberOfWheels, string bodyVolume) {
            Brand = truck.Brand;
            Model = truck.Model;
            Power = truck.Power;
            MaximumSpeed = truck.MaximumSpeed;
            RegistrationNumber = registrationNumber;
            NumberOfWheels = numberOfWheels;
            BodyVolume = bodyVolume;
        }
    }
}
