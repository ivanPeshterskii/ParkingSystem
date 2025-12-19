using System;
using ParkingSystem.Data.Models;

namespace ParkingSystem.Repository.Contracts
{
	public interface ICarRepository
	{
		IEnumerable<Car> GetAll();
		void Add(Car car);
		void Delete(string plateNumber);
		Car GetByPlate(string plateNumber);
	}
}

