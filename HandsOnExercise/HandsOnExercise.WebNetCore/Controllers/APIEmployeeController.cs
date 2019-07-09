using HandsOnExercise.BusinessLogic;
using HandsOnExercise.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnExercise.WebNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIEmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIEmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/APIEmployee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOEmployee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/APIEmployee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOEmployee>> GetEmployee(int id)
        {
            var dTOEmployee = await _context.Employees.FindAsync(id);

            if (dTOEmployee == null)
            {
                return NotFound();
            }

            return dTOEmployee;
        }

        // PUT: api/APIEmployee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromBody]DTOEmployee dTOEmployee)
        {
            if (id != dTOEmployee.id)
            {
                return BadRequest();
            }

            _context.Entry(dTOEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTOEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/APIEmployee
        [HttpPost]
        public async Task<ActionResult<DTOEmployee>> PostEmployee([FromBody]DTOEmployee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.id }, employee);
        }

        // DELETE: api/APIEmployee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOEmployee>> DeleteEmployee(int id)
        {
            var dTOEmployee = await _context.Employees.FindAsync(id);
            if (dTOEmployee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(dTOEmployee);
            await _context.SaveChangesAsync();

            return dTOEmployee;
        }

        private bool DTOEmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.id == id);
        }
    }
}
