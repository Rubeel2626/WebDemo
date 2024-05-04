using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebDemo.Context.ApplicationDb;
using WebDemo.Context.Model;

namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetEmployee()
        {
            try
            {
                var getData = await _context.Employee!.ToListAsync();
                return Ok(new
                {
                    status = 1,
                    response = getData
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    response = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutClass(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    status = 1,
                    response = employee
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = 0,
                    response = ex.Message
                });
            }

        }


        [HttpPost]
        public async Task<ActionResult<Employee>> PostClass(Employee employee)
        {
            try
            {
                if (_context.Employee == null)
                {
                    return BadRequest(new
                    {
                        status = 0,
                        response = "Entity is null."
                    });
                }
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    status = 1,
                    response = employee
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    response = ex.Message
                });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var findData = await _context.Employee.FindAsync(id);
            if (findData == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(findData);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                status = 1,
                response = "Success"
            });
            //return NoContent();
        }


    }
}
