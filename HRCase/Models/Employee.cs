namespace HRCase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeCode { get; set; }  // unique code

        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } // Active, Inactive, etc.
    }
}
