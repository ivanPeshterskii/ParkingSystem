using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(DataAccess.Cars);
        }
    }
}

