using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCKH.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string CodeEmployee { get; set; }
        [Display(Name = "EmployeeName")]
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? StartDatetime { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Roles { get; set; }
    }
}
