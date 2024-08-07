using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using NCKH.Service;

namespace NCKH.Controllers
{
    public class LoginController : Controller
    {
        private readonly EmployeeService employeeService;
        public LoginController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult Login(string email, string password)
        {
            Employee employee = employeeService.CheckEmailAndPass(email, password);
            if(employee != null) {
                // Lưu thông tin người dùng vào session
                HttpContext.Session.SetString("CodeEmployee", employee.CodeEmployee.ToString());
                HttpContext.Session.SetInt32("Id", employee.Id);
                HttpContext.Session.SetString("EmployeeName", employee.EmployeeName);
              
                // Đăng nhập thành công, chuyển hướng đến trang chính
                return Redirect($"/admin/home/");
            }
            return Redirect($"/home");
        }
    }
}
