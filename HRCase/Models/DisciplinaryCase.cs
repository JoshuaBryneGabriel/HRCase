namespace HRCase.Models
{
    // Models/DisciplinaryCase.cs
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DisciplinaryCase
    {
        [Key]
        public int CaseId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [MaxLength(500)]
        public string Violation { get; set; }

        public DateTime CaseDate { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } // Pending, Under Review, Approved, Rejected

        public string Remarks { get; set; }
    }

}
