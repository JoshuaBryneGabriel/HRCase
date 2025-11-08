using HRCase.Data;
using HRCase.Models;
using Microsoft.EntityFrameworkCore;
// Services/ExcelService.cs
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRCase.Services
{
    public class ExcelService
    {
        private readonly AppDbContext _db;
        public ExcelService(AppDbContext db)
        {
            _db = db;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        /// <summary>
        /// Import rows from the first worksheet into TblEmpLog.
        /// Expects header row (row 1). Headers are matched in a case-insensitive,
        /// whitespace- and punctuation-normalized manner (e.g. "Emp ID", "empid", "EMPID").
        /// Behavior: rows with empty EmpId are skipped; rows with an existing EmpId are skipped (no update).
        /// </summary>
        public async Task<(int inserted, int skipped)> ImportTblEmpLogFromExcelAsync(Stream excelStream)
        {
            if (excelStream == null) throw new ArgumentNullException(nameof(excelStream));


            using var package = new ExcelPackage(excelStream);
            var ws = package.Workbook.Worksheets.FirstOrDefault();
            if (ws == null) return (0, 0);

            // read header -> map column index
            var headerMap = new Dictionary<int, string>();

            for (int col = ws.Dimension.Start.Column; col <= ws.Dimension.End.Column; col++)
            {
                var raw = ws.Cells[1, col].Text?.Trim();
                if (string.IsNullOrEmpty(raw)) continue;
                headerMap[col] = NormalizeHeader(raw);
            }

            if (!headerMap.Any()) return (0, 0);

            // load existing EmpIds to avoid duplicates in this test upload
            var existingEmpIds = await _db.TblEmpLogs
                                         .AsNoTracking()
                                         .Select(t => t.EmpId)
                                         .Where(x => x != null)
                                         .ToListAsync();

            int inserted = 0, skipped = 0;
            for (int row = 2; row <= ws.Dimension.End.Row; row++)
            {
                // Read EmpId first (common key)
                string empId = GetCellText(ws, row, headerMap, "empid");
                if (string.IsNullOrWhiteSpace(empId))
                {
                    skipped++;
                    continue;
                }

                if (existingEmpIds.Contains(empId))
                {
                    // skip existing for this simple test import
                    skipped++;
                    continue;
                }

                var entry = new TblEmpLog
                {
                    EmpId = Truncate(GetCellText(ws, row, headerMap, "empid"), 50),
                    Password = Truncate(GetCellText(ws, row, headerMap, "password"), 100),
                    AccessLevel = Truncate(GetCellText(ws, row, headerMap, "accesslevel"), 50),
                    Status = Truncate(GetCellText(ws, row, headerMap, "status"), 50),
                    Agent = Truncate(GetCellText(ws, row, headerMap, "agent"), 100),
                    LastName = Truncate(GetCellText(ws, row, headerMap, "lastname"), 100),
                    FirstName = Truncate(GetCellText(ws, row, headerMap, "firstname"), 100),
                    MiddleName = Truncate(GetCellText(ws, row, headerMap, "middlename"), 100),
                    Department = Truncate(GetCellText(ws, row, headerMap, "department"), 100),
                    Title1 = Truncate(GetCellText(ws, row, headerMap, "title1"), 100),
                    Title2 = Truncate(GetCellText(ws, row, headerMap, "title2"), 100),
                    AccountHandled = GetCellText(ws, row, headerMap, "accounthandled"),
                    PrimaryEmpId = Truncate(GetCellText(ws, row, headerMap, "primaryempid"), 50),
                    PrimaryReport = Truncate(GetCellText(ws, row, headerMap, "primaryreport"), 100),
                    SecondaryEmpId = Truncate(GetCellText(ws, row, headerMap, "secondaryempid"), 50),
                    SecondaryReport = Truncate(GetCellText(ws, row, headerMap, "secondaryreport"), 100),
                    Grade = Truncate(GetCellText(ws, row, headerMap, "grade"), 50),
                    Category = Truncate(GetCellText(ws, row, headerMap, "category"), 50),
                    Unit = Truncate(GetCellText(ws, row, headerMap, "unit"), 100),
                    NtLogin = Truncate(GetCellText(ws, row, headerMap, "ntlogin"), 100),
                    Email = Truncate(GetCellText(ws, row, headerMap, "email"), 500),
                    ImageUrl = Truncate(GetCellText(ws, row, headerMap, "imageurl"), 200),
                    CodeId = Truncate(GetCellText(ws, row, headerMap, "codeid"), 200),
                    Uploader = Truncate(GetCellText(ws, row, headerMap, "uploader"), 100),
                    LineHr = GetCellText(ws, row, headerMap, "linehr"),
                    VerifyInfo = Truncate(GetCellText(ws, row, headerMap, "verifyinfo"), 50),
                    Address = Truncate(GetCellText(ws, row, headerMap, "address"), 1000),
                    ContactNum = Truncate(GetCellText(ws, row, headerMap, "contactnum"), 100),
                    Location = Truncate(GetCellText(ws, row, headerMap, "location"), 100),
                    Bldg = Truncate(GetCellText(ws, row, headerMap, "bldg"), 50),
                    Gender = Truncate(GetCellText(ws, row, headerMap, "gender"), 50),
                    NickName = Truncate(GetCellText(ws, row, headerMap, "nickname"), 100),
                    Sss = Truncate(GetCellText(ws, row, headerMap, "sss"), 50),
                    Tin = Truncate(GetCellText(ws, row, headerMap, "tin"), 50),
                    Pagibig = Truncate(GetCellText(ws, row, headerMap, "pagibig"), 50),
                    Philhealth = Truncate(GetCellText(ws, row, headerMap, "philhealth"), 50),
                    ResetBy = Truncate(GetCellText(ws, row, headerMap, "resetby"), 500),
                    HealthCard = GetCellText(ws, row, headerMap, "healthcard")
                };

                // parse dates
                entry.DateOfEntry = ParseNullableDate(GetCellText(ws, row, headerMap, "dateofentry"));
                entry.LastEntry = ParseNullableDate(GetCellText(ws, row, headerMap, "lastentry"));
                entry.LastBulkUpdate = ParseNullableDate(GetCellText(ws, row, headerMap, "lastbulkupdate"));
                entry.HireDate = ParseNullableDate(GetCellText(ws, row, headerMap, "hiredate"));
                entry.CertificationDate = ParseNullableDate(GetCellText(ws, row, headerMap, "certificationdate"));
                entry.RegularizationDate = ParseNullableDate(GetCellText(ws, row, headerMap, "regularizationdate"));
                entry.SeparationDate = ParseNullableDate(GetCellText(ws, row, headerMap, "separationdate"));
                entry.ResetDate = ParseNullableDate(GetCellText(ws, row, headerMap, "resetdate"));

                // UpdateFlag (short)
                var updateFlagText = GetCellText(ws, row, headerMap, "updateflag");
                if (short.TryParse(updateFlagText, out var s)) entry.UpdateFlag = s;

                // Add and record
                _db.TblEmpLogs.Add(entry);
                existingEmpIds.Add(entry.EmpId); // prevent duplicates in same upload
                inserted++;
            }

            await _db.SaveChangesAsync();
            return (inserted, skipped);
        }

        // Helper: normalize header text for matching
        private static string NormalizeHeader(string header)
        {
            if (header == null) return string.Empty;
            var s = new string(header.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLowerInvariant();
            return s;
        }

        // Helper: get text by normalized header name
        private static string GetCellText(ExcelWorksheet ws, int row, Dictionary<int, string> headerMap, string normalizedHeader)
        {
            var col = headerMap.FirstOrDefault(kv => kv.Value == NormalizeHeader(normalizedHeader)).Key;
            if (col == 0) return string.Empty;
            return ws.Cells[row, col]?.Text?.Trim() ?? string.Empty;
        }

        private static DateTime? ParseNullableDate(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var dt))
                return dt;
            return null;
        }

        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
