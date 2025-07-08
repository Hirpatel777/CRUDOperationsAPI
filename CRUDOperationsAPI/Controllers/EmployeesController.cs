using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDOperationsAPI.Models;
using Microsoft.EntityFrameworkCore;
using CRUDOperationsAPI.Services;
namespace CRUDOperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataStore _store;

        public EmployeesController(DataStore store)
        {
            _store = store;
        }

        // GET: api/employee
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = from emp in _store.Employees
                            join dept in _store.Departments on emp.DepartmentId equals dept.DeptId
                            select new
                            {
                                emp.EmpId,
                                emp.Name,
                                emp.Email,
                                Department = dept.DeptName
                            };

            return Ok(employees);
        }

        // GET: api/employee/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _store.Employees.FirstOrDefault(e => e.EmpId == id);
            if (employee == null) return NotFound();

            var department = _store.Departments.FirstOrDefault(d => d.DeptId == employee.DepartmentId);
            return Ok(new
            {
                employee.EmpId,
                employee.Name,
                employee.Email,
                Department = department?.DeptName
            });
        }

        // POST: api/employee
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            emp.EmpId = _store.Employees.Max(e => e.EmpId) + 1;
            _store.Employees.Add(emp);
            return Ok(emp);
        }

        // PUT: api/employee/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updated)
        {
            var emp = _store.Employees.FirstOrDefault(e => e.EmpId == id);
            if (emp == null) return NotFound();

            emp.Name = updated.Name;
            emp.Email = updated.Email;
            emp.DepartmentId = updated.DepartmentId;

            return Ok(emp);
        }

        // DELETE: api/employee/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _store.Employees.FirstOrDefault(e => e.EmpId == id);
            if (emp == null) return NotFound();

            _store.Employees.Remove(emp);
            return NoContent();
        }


    }
}

