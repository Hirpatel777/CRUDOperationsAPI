using CRUDOperationsAPI.Models;

namespace CRUDOperationsAPI.Services
{
    public class DataStore
    {
        public List<Employee> Employees { get; set; } = new List<Employee>
    {
        new Employee { EmpId = 1, Name = "John", Email = "john@example.com", DepartmentId = 1 },
        new Employee { EmpId = 2, Name = "Sara", Email = "sara@example.com", DepartmentId = 2 }
    };

        public List<Department> Departments { get; set; } = new List<Department>
    {
        new Department { DeptId = 1, DeptName = "HR" },
        new Department { DeptId = 2, DeptName = "IT" }
    };
    }
}
