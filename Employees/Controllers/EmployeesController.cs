﻿using Employees.DB;
using Employees.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApiContext _context;

        public EmployeesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> getEmployee(uint id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> createEmployee(Employee employee)
        {
            try
            {
                if (EmployeeExists(employee.id))
                {
                    return Conflict();
                }

                _context.Add(employee);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // logginf error
                return BadRequest();
            }

            return Ok(true);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> updateEmployee(Employee employee)
        {
            try
            {
                if (!EmployeeExists(employee.id))
                {
                    return NotFound();
                }

                _context.Entry(employee).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(uint id)
        {
            try
            {
                var employee = await _context.employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.employees.Remove(employee);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                // logging error
                return false;
            }

            return true;
        }

        private bool EmployeeExists(uint id)
        {
            return _context.employees.Any(e => e.id == id);
        }
    }
}
