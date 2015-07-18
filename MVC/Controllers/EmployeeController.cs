using MVC.BusinessLayer;
using MVC.Models;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public string GetString()
        {
            return "Hello World is gone! Say Wassup!";
        }


        [NonAction]
        public string NonActionMethod()
        {
            return "Hi, I am not an action method";
        }

        [Authorize]
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.GetEmployees();

            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in employees)
            {
                EmployeeViewModel empVM = new EmployeeViewModel();
                empVM.EmployeeName = employee.FirstName + " " + employee.LastName;
                empVM.Salary = employee.Salary.ToString("C");

                if (employee.Salary >= 15000)
                    empVM.SalaryColor = "yellow";
                else
                    empVM.SalaryColor = "green";

                employeeViewModels.Add(empVM);
            }

            EmployeeListViewModel empLVM = new EmployeeListViewModel() { EmployeeViewModels = employeeViewModels };
            empLVM.UserName = User.Identity.Name;
            return View("Index", empLVM);
        }

        public ActionResult AddNew()
        {
            return View("AddEmployee");
        }

        public ActionResult SaveEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer ebl = new EmployeeBusinessLayer();
                Employee emp = ebl.SaveEmployee(e);
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddEmployee");
            }

            return new EmptyResult(); 
        }
    }
}