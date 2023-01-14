using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CS
{
    internal class PassengerCar : ICarBrand {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Power { get; set; }
        public string MaximumSpeed { get; set; }
        public string RegistrationNumber { get; set; }
        public string MediaName { get; set; }
        public string NumberOfAirbags { get; set; }

        public PassengerCar(string brand, string model, string power, string maximumSpeed) {
            Brand = brand;
            Model = model;
            Power = power;
            MaximumSpeed = maximumSpeed;
        }

        public PassengerCar(ICarBrand passengerCar, string registrationNumber, string mediaName, string numberOfAirbags) {
            Brand = passengerCar.Brand;
            Model = passengerCar.Model;
            Power = passengerCar.Power;
            MaximumSpeed = passengerCar.MaximumSpeed;
            RegistrationNumber = registrationNumber;
            MediaName = mediaName;
            NumberOfAirbags = numberOfAirbags;
        }
    }
}
