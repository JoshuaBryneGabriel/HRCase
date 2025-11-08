using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRCase.Models
{
    [Table("TblEmpLog")]
    public class TblEmpLog
    {
        [Key]
        [Column("autoid")]
        public int AutoId { get; set; }

        [Column("empid"), MaxLength(50)]
        public string EmpId { get; set; }

        [Column("password"), MaxLength(100)]
        public string Password { get; set; }

        [Column("accesslevel"), MaxLength(50)]
        public string AccessLevel { get; set; }

        [Column("status"), MaxLength(50)]
        public string Status { get; set; }

        [Column("agent"), MaxLength(100)]
        public string Agent { get; set; }

        [Column("lastname"), MaxLength(100)]
        public string LastName { get; set; }

        [Column("firstname"), MaxLength(100)]
        public string FirstName { get; set; }

        [Column("middlename"), MaxLength(100)]
        public string MiddleName { get; set; }

        [Column("department"), MaxLength(100)]
        public string Department { get; set; }

        [Column("title1"), MaxLength(100)]
        public string Title1 { get; set; }

        [Column("title2"), MaxLength(100)]
        public string Title2 { get; set; }

        [Column("accounthandled")]
        public string AccountHandled { get; set; }

        [Column("primaryempid"), MaxLength(50)]
        public string PrimaryEmpId { get; set; }

        [Column("primaryreport"), MaxLength(100)]
        public string PrimaryReport { get; set; }

        [Column("secondaryempid"), MaxLength(50)]
        public string SecondaryEmpId { get; set; }

        [Column("secondaryreport"), MaxLength(100)]
        public string SecondaryReport { get; set; }

        [Column("grade"), MaxLength(50)]
        public string Grade { get; set; }

        [Column("category"), MaxLength(50)]
        public string Category { get; set; }

        [Column("unit"), MaxLength(100)]
        public string Unit { get; set; }

        [Column("ntlogin"), MaxLength(100)]
        public string NtLogin { get; set; }

        [Column("email"), MaxLength(500)]
        public string Email { get; set; }

        [Column("imageurl"), MaxLength(200)]
        public string ImageUrl { get; set; }

        [Column("codeid"), MaxLength(200)]
        public string CodeId { get; set; }

        [Column("uploader"), MaxLength(100)]
        public string Uploader { get; set; }

        [Column("linehr")]
        public string LineHr { get; set; }

        [Column("verifyinfo"), MaxLength(50)]
        public string VerifyInfo { get; set; }

        [Column("dateofentry")]
        public DateTime? DateOfEntry { get; set; }

        [Column("lastentry")]
        public DateTime? LastEntry { get; set; }

        [Column("lastbulkupdate")]
        public DateTime? LastBulkUpdate { get; set; }

        [Column("gender"), MaxLength(50)]
        public string Gender { get; set; }

        [Column("nickname"), MaxLength(100)]
        public string NickName { get; set; }

        [Column("address"), MaxLength(1000)]
        public string Address { get; set; }

        [Column("contactnum"), MaxLength(100)]
        public string ContactNum { get; set; }

        [Column("location"), MaxLength(100)]
        public string Location { get; set; }

        [Column("bldg"), MaxLength(50)]
        public string Bldg { get; set; }

        [Column("hiredate")]
        public DateTime? HireDate { get; set; }

        [Column("certificationdate")]
        public DateTime? CertificationDate { get; set; }

        [Column("regularizationdate")]
        public DateTime? RegularizationDate { get; set; }

        [Column("separationdate")]
        public DateTime? SeparationDate { get; set; }

        [Column("sss"), MaxLength(50)]
        public string Sss { get; set; }

        [Column("tin"), MaxLength(50)]
        public string Tin { get; set; }

        [Column("pagibig"), MaxLength(50)]
        public string Pagibig { get; set; }

        [Column("philhealth"), MaxLength(50)]
        public string Philhealth { get; set; }

        [Column("ResetBy"), MaxLength(500)]
        public string ResetBy { get; set; }

        [Column("ResetDate")]
        public DateTime? ResetDate { get; set; }

        [Column("HealthCard")]
        public string HealthCard { get; set; }

        [Column("UpdateFlag")]
        public short? UpdateFlag { get; set; }

        // Relationship to ENTblData
        public ICollection<ENTblData> DisciplinaryCases { get; set; } = new List<ENTblData>();
    }
}
