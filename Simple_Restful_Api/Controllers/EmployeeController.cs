
using System;
using Simple_Restful_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Simple_Restful_Api.Controllers
{
    //this controller to implement the crud operation
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly EmployeeDb db;

        public EmployeeController(EmployeeDb db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        /// <summary>
        /// Gets all employee information
        /// </summary>
        /// <returns>all employees information</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            var employees = await db.Employees.ToListAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        /// <summary>
        /// Gets a single employee by id
        /// </summary>
        /// <param name="id">The ID of the message to return</param>
        /// <returns>return a employee information by id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee!;
        }

        /// <summary>
        /// Creates a new employee
        /// </summary>
        /// <param name="employee">The new employee to create</param>
        /// <returns>a success code if the employee has been created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Employee>> PostEmployee(Employee e)
        {
            db.Employees.Add(e);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee),new { id = e.Id }, e);
        }


        /// <summary>
        /// Updates the employee if it exists
        /// </summary>
        /// <param name="id">The employee to update</param>
        /// <param name="e">The request body</param>
        /// <returns>A 404 response if the employee doesn't exist, or a 204 if it has been updated</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateEmployee(int id, Employee e)
        { 
            var oldEmployee = await db.Employees.FindAsync(id);
            if (oldEmployee is null) return BadRequest();

            oldEmployee.Age = e.Age==0 ?  oldEmployee.Age : e.Age;
            oldEmployee.Name = e.Name ?? oldEmployee.Name;
            oldEmployee.Salary = e.Salary==0 ? oldEmployee.Salary:e.Salary;
            await db.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes a employee if it exists
        /// </summary>
        /// <param name="id">The ID of the employee to delete</param>
        /// <returns>A 200 OK response</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee is null)
            {
                return Ok("there is no such employee");
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok("the target employee is deleted");
        }
    }
}

