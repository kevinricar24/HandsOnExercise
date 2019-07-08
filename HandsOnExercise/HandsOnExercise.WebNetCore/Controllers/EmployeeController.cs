using HandsOnExercise.BusinessLogic;
using HandsOnExercise.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnExercise.WebNetCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employee/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dTOEmployee = await _context.Employees
                .FirstOrDefaultAsync(m => m.id == id);
            if (dTOEmployee == null)
            {
                return NotFound();
            }

            return View(dTOEmployee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,contractTypeName,roleId,roleName,roleDescription,hourlySalary,monthlySalary")] DTOEmployee dTOEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dTOEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dTOEmployee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dTOEmployee = await _context.Employees.FindAsync(id);
            if (dTOEmployee == null)
            {
                return NotFound();
            }
            return View(dTOEmployee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,contractTypeName,roleId,roleName,roleDescription,hourlySalary,monthlySalary")] DTOEmployee dTOEmployee)
        {
            if (id != dTOEmployee.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dTOEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DTOEmployeeExists(dTOEmployee.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dTOEmployee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dTOEmployee = await _context.Employees
                .FirstOrDefaultAsync(m => m.id == id);
            if (dTOEmployee == null)
            {
                return NotFound();
            }

            return View(dTOEmployee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dTOEmployee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(dTOEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DTOEmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.id == id);
        }

       
    }
}
