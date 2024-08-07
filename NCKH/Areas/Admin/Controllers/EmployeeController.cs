using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using NCKH.Service;

namespace NCKH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService employeeService;
        private readonly RoleService roleService;   
        public EmployeeController(EmployeeService employeeService, RoleService roleService) {
            this.employeeService = employeeService;
            this.roleService = roleService;
        }
        public IActionResult Index()
        {
            List<Employee> employees = employeeService.GetAllEmployee();
            return View(employees);
        }
        public IActionResult CreateEmployee()
        {
            List<Role> rolelisst = roleService.GetAllRoles();
            return View(rolelisst);
        }
        public IActionResult Create(Employee employee)
        {
            Employee employee1= employeeService.GetEmployeeByCodeEmployee(employee.CodeEmployee);
            if(employee1 == null) {
                    employeeService.AddEmployee(employee);
            }
            else
            {
                return Redirect("/admin/employee/CreateEmployee");

            }
            return Redirect("/admin/employee");
        }

        public IActionResult Editemployee(int id)
        {
            List<Role> roles = roleService.GetAllRoles();
           
                Employee employee = employeeService.GetEmployeeById(id);
                ModelDataset model = new ModelDataset()
                {
                    employee = employee,
                    Roles  = roles
                };
           
            return View(model);
        }
        public IActionResult Edit(Employee employee)
        {
            Employee employee1= employeeService.GetEmployeeById(employee.Id);
            employee.Password = employee1.Password;
            employeeService.UpdateEmployee(employee);
            return Redirect("/admin/employee");
        }
        public IActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);
            return Redirect("/admin/employee");
        }
    }
}
