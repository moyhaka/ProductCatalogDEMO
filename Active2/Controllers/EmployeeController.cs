using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Active2.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MsgTest()
        {
            return View("This is a test");
        }


        public IActionResult WelcomeManager(string name = "Karen", string lastName = "Karen")
        {
            ViewBag.Name = name;
            ViewBag.Lastname = lastName;
            return View();
        }
    }
}
