using HandsOnExercise.BusinessLogic;
using HandsOnExercise.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnExercise.WebNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployeeById(string id)
        {
            List<DTOEmployee> employees = new List<DTOEmployee>();
            if (!string.IsNullOrEmpty(id))
            {
                DTOEmployee employee = _context.Employees.FirstOrDefault(x => x.id == int.Parse(id));
                if (employee != null)
                {
                    employees.Add(employee);
                }
            }
            else
            {
                employees = _context.Employees.ToList();
            }
            return Json(employees);
        }

        public string InsertEmployee(DTOEmployee employee)
        {
            if (employee != null)
            {
                _context.Add(employee);
                _context.SaveChanges();
                return "Employee Added Successfully";
            }
            else
            {
                return "Employee Not Inserted! Try Again";
            }
        }

        public JsonResult DeleteEmployee(int id)
        {
            var dTOEmployee = _context.Employees.Find(id);
            _context.Employees.Remove(dTOEmployee);
            _context.SaveChanges();
            List<DTOEmployee> employees = _context.Employees.ToList();
            return Json(employees);
    } 

    }
}