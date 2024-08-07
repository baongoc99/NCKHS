using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NCKH.Models
{

    /// <summary>
    ///  giỏ hành cuark hách hàng
    /// </summary>
    public class OrderDetailCustomer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
