using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCKH.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartDatetime { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total  { get; set; }// tổng tiền
        public string Status { get; set; } /// chờ xác nhận, chờ lấy hàng chờ giao hàng, đã giao, đã huỷ, trả hàng
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
