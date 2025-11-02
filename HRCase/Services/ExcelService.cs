using HRCase.Data;
using HRCase.Models;
using Microsoft.EntityFrameworkCore;
// Services/ExcelService.cs
using OfficeOpenXml;
using System.Collections.Generic;
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
            // EPPlus license context
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // change to Commercial appropriately
        }

        public async Task<(int inserted, int skipped)> ImportEmployeesFromExcelAsync(Stream excelStream)
        {
            using var package = new ExcelPackage(excelStream);
            var ws = package.Workbook.Worksheets.FirstOrDefault();
            if (ws == null) return (0, 0);

            // Assumption: first row is header; columns: EmployeeCode, FullName, Department, Position, Status
            var startRow = 2;
            var inserted = 0;
            var skipped = 0;

            var existingCodes = await _db.Employees.Select(e => e.EmployeeCode).ToListAsync();

            for (int row = startRow; row <= ws.Dimension.End.Row; row++)
            {
                var code = ws.Cells[row, 1]?.Text?.Trim();
                if (string.IsNullOrWhiteSpace(code))
                {
                    skipped++;
                    continue;
                }

                // if already exists, skip (do not overwrite)
                if (existingCodes.Contains(code))
                {
                    skipped++;
                    continue;
                }

                var emp = new Employee
                {
                    EmployeeCode = code,
                    FullName = ws.Cells[row, 2]?.Text?.Trim(),
                    Department = ws.Cells[row, 3]?.Text?.Trim(),
                    Position = ws.Cells[row, 4]?.Text?.Trim(),
                    Status = ws.Cells[row, 5]?.Text?.Trim()
                };

                _db.Employees.Add(emp);
                existingCodes.Add(code); // prevent duplicate in same upload
                inserted++;
            }

            await _db.SaveChangesAsync();
            return (inserted, skipped);
        }

        public async Task<byte[]> ExportEmployeesToExcelAsync(string departmentFilter = null)
        {
            var query = _db.Employees.AsQueryable();
            if (!string.IsNullOrWhiteSpace(departmentFilter))
                query = query.Where(e => e.Department == departmentFilter);

            var list = await query.ToListAsync();

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Employees");

            // header
            ws.Cells[1, 1].Value = "EmployeeCode";
            ws.Cells[1, 2].Value = "FullName";
            ws.Cells[1, 3].Value = "Department";
            ws.Cells[1, 4].Value = "Position";
            ws.Cells[1, 5].Value = "Status";

            int row = 2;
            foreach (var e in list)
            {
                ws.Cells[row, 1].Value = e.EmployeeCode;
                ws.Cells[row, 2].Value = e.FullName;
                ws.Cells[row, 3].Value = e.Department;
                ws.Cells[row, 4].Value = e.Position;
                ws.Cells[row, 5].Value = e.Status;
                row++;
            }

            return package.GetAsByteArray();
        }
    }

}
