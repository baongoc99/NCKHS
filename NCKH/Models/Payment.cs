using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCKH.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? EndDattetime { get; set; } // ngày thanh toán
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }// tổng tiền
        public string PaymentMethod { get; set; }// phương thức thanh toán ( chueyenr kahonr, tiền mawht)
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employees { get; set; }
    }
}
