using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NCKH.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? StartDattetime { get; set; } // ngày đawntj hàng
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
