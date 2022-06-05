using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get { return cars; } set {cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return cars.Count; } }
        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new List<Car>();
        }
        public Car GetCar(string regNumber)
        {
            return Cars.First(x => x.RegistrationNumber == regNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> regNumbers)
        {
            foreach (var item in regNumbers)
            {
                RemoveCar(item);
            }
        }

        public string RemoveCar(string regNumber)
        {
            bool isExist = false;
            foreach (Car item in Cars)
            {
                if (item.RegistrationNumber == regNumber)
                {
                    isExist = true;
                }
            }
            if (!isExist)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = Cars.First(x => x.RegistrationNumber == regNumber);
                cars.Remove(carToRemove);
                return $"Successfully removed {regNumber}";
            }
        }
        public string AddCar(Car addedCar)
        {
            bool isPossibleToAddCar = true;
            foreach (Car item in Cars)
            {
                if (item.RegistrationNumber == addedCar.RegistrationNumber)
                {
                    isPossibleToAddCar = false;
                    return "Car with that registration number, already exists!";
                }
            }

            if (Cars.Count + 1 > Capacity)
            {
                //isPossibleToAddCar = false;
                return "Parking is full!";
            }

            if (isPossibleToAddCar)
            {
                Cars.Add(addedCar);
                return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
            }
            return "";
        }
    }
}
