using Microsoft.EntityFrameworkCore;
using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Employee CheckEmailAndPass(string email, string password)
        {
            Employee Employee = _context.Employees.FirstOrDefault(u => u.Email == email && u.Password == password);
            return Employee;
        }
        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.Include(e => e.Roles).ToList();
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees
                           .Include(e => e.Roles)
                           .FirstOrDefault(p => p.Id == id);
        }
        public Employee GetEmployeeByCodeEmployee(string CodeEmployee)
        {
            return _context.Employees
                           .FirstOrDefault(p => p.CodeEmployee == CodeEmployee);
        }
      
        public void UpdateEmployee(Employee employee)
        {
            var existingemployee = _context.Employees.SingleOrDefault(u => u.Id == employee.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(employee);
            }
            else
            {
                _context.Employees.Update(employee);
            }
            _context.SaveChanges();
        }
        public void DeleteEmployee(int id) {
            var employeedelete = _context.Employees.Find(id);
            if (employeedelete != null)
            {
                _context.Employees.Remove(employeedelete);
                _context.SaveChanges();
            }

        }
    }
}
