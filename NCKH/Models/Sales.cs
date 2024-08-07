using System.ComponentModel.DataAnnotations;

namespace NCKH.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public string CodeSales { get; set; }
        public int SumQuantity { get; set; }
        public int SumTotals { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? StartDattetime { get; set; } // ngày bắt đầu
        [DataType(DataType.DateTime)]
        public DateTime? EndtDattetime { get; set; } // ngày kết thúc
        public int Percentage { get; set; }// PHẦN TRĂM ĐƯỢC GIẢM GIÁ
        public string Status { get; set; } /// true, flase
        public int Maximum { get; set; } // số lần tối đa sử dụng
        public int TotalUsed { get; set; }// số lần đã sử dụng


    }
}
