using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using UWofS.CS7;

namespace WebApp2.Controllers
{
    public class HomeController : Controller

    {

        private Northwind db;

        public HomeController(Northwind injectedContext)
        {
            db = injectedContext;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Employees = db.Employees.ToList()
            };
            return View(model); //pass the model to the view
        }

        public IActionResult EmployeesView(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("You must pass an employee ID in the route, for example, /Home/EmployeeID/1");
            }
            var model = db.Employees.SingleOrDefault(p => p.EmployeeID == id);
            if (model == null)
            {
                return NotFound($"An employee with the ID of {id} was not found.");
            }
            return View(model); // pass model to view 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
