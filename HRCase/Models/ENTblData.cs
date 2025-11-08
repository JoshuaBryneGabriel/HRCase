using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRCase.Models
{
    [Table("ENTblData")]
    public class ENTblData
    {
        [Key]
        [Column("autoid")]
        public int AutoId { get; set; }

        [Column("empid"), MaxLength(50)]
        public string EmpId { get; set; }

        [Column("agent"), MaxLength(500)]
        public string Agent { get; set; }

        [Column("Department"), MaxLength(100)]
        public string Department { get; set; }

        [Column("Designation"), MaxLength(100)]
        public string Designation { get; set; }

        [Column("Platform_LOB"), MaxLength(100)]
        public string PlatformLOB { get; set; }

        [Column("sender_ID"), MaxLength(50)]
        public string SenderId { get; set; }

        [Column("sender"), MaxLength(500)]
        public string Sender { get; set; }

        [Column("COC_General_Provision"), MaxLength(500)]
        public string COCGeneralProvision { get; set; }

        [Column("COC_Specific_Provision")]
        public string COCSpecificProvision { get; set; }

        [Column("Date_of_Offense"), MaxLength(500)]
        public string DateOfOffense { get; set; }

        [Column("Details")]
        public string Details { get; set; }

        [Column("Primary_Reportee_Approval"), MaxLength(50)]
        public string PrimaryReporteeApproval { get; set; }

        [Column("Primary_Reportee_Remarks")]
        public string PrimaryReporteeRemarks { get; set; }

        [Column("Primary_Reportee_ID"), MaxLength(50)]
        public string PrimaryReporteeId { get; set; }

        [Column("Primary_Reportee"), MaxLength(500)]
        public string PrimaryReportee { get; set; }

        [Column("Secondary_Reportee_Approval"), MaxLength(50)]
        public string SecondaryReporteeApproval { get; set; }

        [Column("Secondary_Reportee_Remarks")]
        public string SecondaryReporteeRemarks { get; set; }

        [Column("Secondary_Reportee_ID"), MaxLength(50)]
        public string SecondaryReporteeId { get; set; }

        [Column("Secondary_Reportee"), MaxLength(500)]
        public string SecondaryReportee { get; set; }

        [Column("HRBP_Approval"), MaxLength(50)]
        public string HRBPApproval { get; set; }

        [Column("HRBP_Remarks")]
        public string HRBPRemarks { get; set; }

        [Column("HRBP_ID"), MaxLength(50)]
        public string HRBPId { get; set; }

        [Column("HRBP"), MaxLength(500)]
        public string HRBP { get; set; }

        [Column("HRBP_AVP_Approval"), MaxLength(50)]
        public string HRBPAVPApproval { get; set; }

        [Column("HRBP_AVP_Remarks")]
        public string HRBPAVPRemarks { get; set; }

        [Column("HRBP_AVP_ID"), MaxLength(50)]
        public string HRBPAVPId { get; set; }

        [Column("HRBP_AVP"), MaxLength(500)]
        public string HRBPAVP { get; set; }

        [Column("LR_Approval"), MaxLength(50)]
        public string LRApproval { get; set; }

        [Column("LR_Remarks")]
        public string LRRemarks { get; set; }

        [Column("LR_ID"), MaxLength(50)]
        public string LRId { get; set; }

        [Column("LR"), MaxLength(500)]
        public string LR { get; set; }

        [Column("Date_Endorsed_to_LR")]
        public DateTime? DateEndorsedToLR { get; set; }

        [Column("Date_Returned_by_LR_to_HRBP")]
        public DateTime? DateReturnedByLRToHRBP { get; set; }

        [Column("Employee_Reply")]
        public string EmployeeReply { get; set; }

        [Column("Findings")]
        public string Findings { get; set; }

        [Column("Disciplinary_Action"), MaxLength(500)]
        public string DisciplinaryAction { get; set; }

        [Column("COC_Progression"), MaxLength(500)]
        public string COCProgression { get; set; }

        [Column("Resolution_SR_Approval"), MaxLength(50)]
        public string ResolutionSRApproval { get; set; }

        [Column("Resolution_SR_Remarks")]
        public string ResolutionSRRemarks { get; set; }

        [Column("Resolution_SR_ID"), MaxLength(50)]
        public string ResolutionSRId { get; set; }

        [Column("Resolution_SR"), MaxLength(500)]
        public string ResolutionSR { get; set; }

        [Column("Resolution_HRBP_Approval"), MaxLength(50)]
        public string ResolutionHRBPApproval { get; set; }

        [Column("Resolution_HRBP_Remarks")]
        public string ResolutionHRBPRemarks { get; set; }

        [Column("Resolution_HRBP_ID"), MaxLength(50)]
        public string ResolutionHRBPId { get; set; }

        [Column("Resolution_HRBP"), MaxLength(500)]
        public string ResolutionHRBP { get; set; }

        [Column("Date_CF_Created_by_PR")]
        public DateTime? DateCFCreatedByPR { get; set; }

        [Column("Date_CF_Sent_to_HR")]
        public DateTime? DateCFSentToHR { get; set; }

        [Column("Date_CF_Signed_Returned_by_HR")]
        public DateTime? DateCFSignedReturnedByHR { get; set; }

        [Column("Date_CF_Received_by_Employee")]
        public DateTime? DateCFReceivedByEmployee { get; set; }

        [Column("Date_DAF_Created_by_PR")]
        public DateTime? DateDAFCreatedByPR { get; set; }

        [Column("Date_DAF_Submitted_to_HR_by_PR")]
        public DateTime? DateDAFSubmittedToHRByPR { get; set; }

        [Column("Date_DAF_Signed_Returned_by_HR")]
        public DateTime? DateDAFSignedReturnedByHR { get; set; }

        [Column("Date_DAF_Received_by_Employee")]
        public DateTime? DateDAFReceivedByEmployee { get; set; }

        [Column("DOJ"), MaxLength(500)]
        public string DOJ { get; set; }

        [Column("SEPARATION_DATE")]
        public DateTime? SeparationDate { get; set; }

        [Column("status"), MaxLength(50)]
        public string Status { get; set; }

        [Column("statusdate")]
        public DateTime? StatusDate { get; set; }

        [Column("codeid"), MaxLength(500)]
        public string CodeId { get; set; }

        [Column("Primary_Reportee_Time")]
        public DateTime? PrimaryReporteeTime { get; set; }

        [Column("Secondary_Reportee_Time")]
        public DateTime? SecondaryReporteeTime { get; set; }

        [Column("HRBP_Time")]
        public DateTime? HRBPTime { get; set; }

        [Column("Employee_Reply_Time")]
        public DateTime? EmployeeReplyTime { get; set; }

        [Column("Resolution_Time")]
        public DateTime? ResolutionTime { get; set; }

        [Column("Resolution_SR_Time")]
        public DateTime? ResolutionSRTime { get; set; }

        [Column("LR_Time")]
        public DateTime? LRTime { get; set; }

        [Column("Resolution_HRBP_Time")]
        public DateTime? ResolutionHRBPTime { get; set; }

        [Column("DAF_Signed_Time")]
        public DateTime? DAFSignedTime { get; set; }

        [Column("Finalized_Time")]
        public DateTime? FinalizedTime { get; set; }

        [Column("dateoffollowup")]
        public DateTime? DateOfFollowup { get; set; }

        [Column("currentstatus"), MaxLength(500)]
        public string CurrentStatus { get; set; }

        [Column("history")]
        public string History { get; set; }

        [Column("Employment_Status"), MaxLength(500)]
        public string EmploymentStatus { get; set; }

        [Column("Employment_Stautus"), MaxLength(500)]
        public string EmploymentStautus { get; set; }

        // Relationship to TblEmpLog
        [ForeignKey(nameof(EmpId))]
        public TblEmpLog? Employee { get; set; }
    }
}
