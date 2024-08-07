﻿using System.ComponentModel.DataAnnotations;

namespace NCKH.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Customer Type")]
        public string CustomerType { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? RecordCreatedOn { get; set; }  
    }

}
