using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using ParkingSystem.Repository;
using ParkingSystem.Repository.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository repository;

        public HomeController(ICarRepository repository)
        {
            this.repository = repository;
        }


        public IActionResult Index()
        {
            var cars = this.repository.GetAll();
            return View(cars);
        }
    }
}

