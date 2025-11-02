namespace HRCase.Models
{
    // Models/Approval.cs
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Approval
    {
        [Key]
        public int ApprovalId { get; set; }

        [Required]
        public int CaseId { get; set; }

        [ForeignKey(nameof(CaseId))]
        public DisciplinaryCase DisciplinaryCase { get; set; }

        [MaxLength(200)]
        public string ApprovedBy { get; set; }

        public DateTime ApprovalDate { get; set; }

        [MaxLength(50)]
        public string Decision { get; set; } // Approved / Rejected

        public string Notes { get; set; }
    }

}
