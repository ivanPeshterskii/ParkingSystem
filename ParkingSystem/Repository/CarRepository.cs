using System;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;
using ParkingSystem.Repository.Contracts;

namespace ParkingSystem.Repository
{
	public class CarRepository : ICarRepository
	{
        private readonly List<Car> cars;

		public CarRepository()
		{
            this.cars = DataAccess.Cars;
		}

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException(nameof(car));
            }

            this.cars.Add(car);
        }

        public void Delete(string plateNumber)
        {
            var car = GetByPlate(plateNumber);

            if (car != null)
            {
                this.cars.Remove(car);
            }
        }

        public IEnumerable<Car> GetAll()
        {
            return this.cars;
        }

        public Car GetByPlate(string plateNumber)
        {
            return this.cars.FirstOrDefault(c => c.PlateNumber == plateNumber);
        }
    }
}

