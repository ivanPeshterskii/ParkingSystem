using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;
using ParkingSystem.Repository.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingSystem.Controllers.CarController
{
    public class CarController : Controller
    {
        private readonly ICarRepository repository;

        public CarController(ICarRepository repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            this.repository.Add(car);
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult DeleteCar(string plateNumber)
        {
            this.repository.Delete(plateNumber);
            return Redirect("/");
        }
    }
}

