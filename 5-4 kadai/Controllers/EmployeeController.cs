using Microsoft.AspNetCore.Mvc;
using benkyou5_4.WebAPI.Data;     // DbContext の場所
using SharedModels; // Employee.cs の namespace に合わせる

namespace benkyou5_4.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList());
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);  //　ここエラー cs1503
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ⑤ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}



