using NUnit.Framework;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;
using ParkingSystem.Repository;
using ParkingSystem.Repository.Contracts;

namespace ParkingSystem.Test;

public class Tests
{
    // CarRepository Tests

    private ICarRepository repository;

    [SetUp]
    public void Setup()
    {
        this.repository = new CarRepository();

        DataAccess.Cars.Clear();
    }

    [Test]
    public void Constructor_ShouldInitializeEmptyCollection()
    {
        var repo = new CarRepository();

        Assert.IsNull(this.repository.GetAll(), "The Cars collection should not be null.");
        Assert.IsEmpty(this.repository.GetAll(), "The Cars collection should be empty after initialization.");
    }


    [Test]
    public void AddCar_ShouldAddACar()
    {
        var car = new Car { CarMake = "BMW", PlateNumber = "PA9123KB" };

        repository.Add(car);

        Assert.Contains(car, this.repository.GetAll().ToList());
    }

    [Test]
    public void AddCar_ShouldThrowExceptionWhenNull()
    {
        var car = new Car { CarMake = " ", PlateNumber = " " };

        Assert.Throws<ArgumentNullException>(() =>
        {
            this.repository.Add(car);
        });
    }

    [Test]
    public void DeleteCar_ShouldDeleteAcar()
    {
        var car = new Car { CarMake = "BMW", PlateNumber = "PA9123KB" };

        this.repository.Add(car);

        this.repository.Delete("PA9123KB");

        Assert.IsFalse(this.repository.GetAll().Contains(car));
    }

    [Test]
    public void GetByPlate_ShouldReturnCorrectCar()
    {
        var car = new Car { CarMake = "BMW", PlateNumber = "PA9123KB" };
        this.repository.Add(car);

        var found = this.repository.GetByPlate("PA9123KB");

        Assert.AreEqual(car, found);
    }

    [Test]
    public void GetByPlate_ShouldReturnNull_IfCarNotFound()
    {
        var plate = this.repository.GetByPlate("A1123KA");

        Assert.IsNull(plate);
    }
}
