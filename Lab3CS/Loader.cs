using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3CS
{
    public class Loader {

        private static Dictionary<string, ICarBrand[]> dataBase = new Dictionary<string, ICarBrand[]>();
        public int numberOfEntries;
        private int progress;
        private ICarBrand carBrand;

        public Loader(ICarBrand carBrand) {
            this.carBrand = carBrand;
            if (dataBase.ContainsKey(ICarBrandToKey(carBrand))) {
                numberOfEntries = dataBase[ICarBrandToKey(carBrand)].Length;
                progress = numberOfEntries + 1;
            } else {
                Random random = new Random();
                numberOfEntries = random.Next(10, 21);
                progress = 0;
            }
        }

        public void load() {
            if (!dataBase.ContainsKey(ICarBrandToKey(carBrand))) {
                Random random = new Random();
                ICarBrand[] carBrands = new ICarBrand[numberOfEntries];
                string[] multimedias = new string[] {"abs" , "hex", "roud", "mif"};
                for (int i = 0; i < numberOfEntries; i++) {
                    Thread.Sleep(random.Next(500));
                    if (carBrand is PassengerCar) {
                        carBrands[i] = new PassengerCar(carBrand, random.Next(1, 10000).ToString(), multimedias[random.Next(4)], random.Next(1, 5).ToString());
                    } else {
                        carBrands[i] = new Truck(carBrand, random.Next(1, 10000).ToString(), (random.Next(2, 6)*2).ToString(), (random.Next(20, 201)*100).ToString());
                    }
                    progress++;
                }
                dataBase.Add(ICarBrandToKey(carBrand), carBrands);
                Thread.Sleep(500);
                progress++;
            }
        }

        public ICarBrand[] get() {
            return dataBase[ICarBrandToKey(carBrand)];
        }

        private string ICarBrandToKey(ICarBrand carBrand) {
            return carBrand.Brand + "." + carBrand.Model + "." + (carBrand is PassengerCar).ToString();
        }

        public int getProgress() {
            if (progress < numberOfEntries + 1) {
                return progress;
            }
            return -1;
        }
    }
}
