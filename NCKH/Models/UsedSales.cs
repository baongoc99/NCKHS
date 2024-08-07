using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NCKH.Models
{
    public class UsedSales
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartDatetime { get; set; }// ngày sử dụng
        public string Status { get; set; } /// chờ xác nhận, chờ lấy hàng chờ giao hàng, đã giao, đã huỷ, trả hàng
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int SalesId { get; set; }

        [ForeignKey("SalesId")]
        public Sales Sales { get; set; }
    }
}
