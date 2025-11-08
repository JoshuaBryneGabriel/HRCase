using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRCase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "TblEmpLog",
                columns: table => new
                {
                    autoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    accesslevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    agent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    middlename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    title1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    title2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    accounthandled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primaryempid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    primaryreport = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    secondaryempid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    secondaryreport = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ntlogin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    imageurl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    codeid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    uploader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    linehr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verifyinfo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dateofentry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastentry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastbulkupdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    contactnum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bldg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hiredate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    certificationdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    regularizationdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    separationdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sss = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pagibig = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    philhealth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResetBy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResetDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HealthCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateFlag = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmpLog", x => x.autoid);
                    table.UniqueConstraint("AK_TblEmpLog_empid", x => x.empid);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaryCases",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Violation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryCases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_DisciplinaryCases_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ENTblData",
                columns: table => new
                {
                    autoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    agent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Platform_LOB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sender_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sender = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    COC_General_Provision = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    COC_Specific_Provision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_Offense = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Primary_Reportee_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Primary_Reportee_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Primary_Reportee_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Primary_Reportee = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Secondary_Reportee_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Secondary_Reportee_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secondary_Reportee_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Secondary_Reportee = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HRBP_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HRBP_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HRBP_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HRBP = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HRBP_AVP_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HRBP_AVP_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HRBP_AVP_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HRBP_AVP = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LR_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LR_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LR_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date_Endorsed_to_LR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Returned_by_LR_to_HRBP = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Employee_Reply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Findings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disciplinary_Action = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    COC_Progression = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Resolution_SR_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resolution_SR_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution_SR_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resolution_SR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Resolution_HRBP_Approval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resolution_HRBP_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution_HRBP_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resolution_HRBP = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date_CF_Created_by_PR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_CF_Sent_to_HR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_CF_Signed_Returned_by_HR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_CF_Received_by_Employee = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_DAF_Created_by_PR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_DAF_Submitted_to_HR_by_PR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_DAF_Signed_Returned_by_HR = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_DAF_Received_by_Employee = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOJ = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SEPARATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    statusdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    codeid = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Primary_Reportee_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Secondary_Reportee_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HRBP_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Employee_Reply_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolution_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolution_SR_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LR_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolution_HRBP_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DAF_Signed_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Finalized_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dateoffollowup = table.Column<DateTime>(type: "datetime2", nullable: true),
                    currentstatus = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    history = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employment_Status = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Employment_Stautus = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTblData", x => x.autoid);
                    table.ForeignKey(
                        name: "FK_ENTblData_TblEmpLog_empid",
                        column: x => x.empid,
                        principalTable: "TblEmpLog",
                        principalColumn: "empid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    ApprovalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.ApprovalId);
                    table.ForeignKey(
                        name: "FK_Approvals_DisciplinaryCases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "DisciplinaryCases",
                        principalColumn: "CaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_CaseId",
                table: "Approvals",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryCases_EmployeeId",
                table: "DisciplinaryCases",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCode",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENTblData_empid",
                table: "ENTblData",
                column: "empid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "ENTblData");

            migrationBuilder.DropTable(
                name: "DisciplinaryCases");

            migrationBuilder.DropTable(
                name: "TblEmpLog");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
