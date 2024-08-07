using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NCKH.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string? Description { get; set; }

    }

}
