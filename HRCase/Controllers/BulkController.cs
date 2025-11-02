using HRCase.Services;
// Controllers/BulkController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace HRCase.Controllers
{

    public class BulkController : Controller
    {
        private readonly ExcelService _excelService;

        public BulkController(ExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View(); // Views/Bulk/Upload.cshtml
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "No file uploaded.";
                return RedirectToAction("Upload");
            }

            using var stream = file.OpenReadStream();
            var (inserted, skipped) = await _excelService.ImportEmployeesFromExcelAsync(stream);

            TempData["Message"] = $"Inserted: {inserted}, Skipped: {skipped}";
            return RedirectToAction("Upload");
        }

        [HttpGet]
        public async Task<IActionResult> DownloadData(string department = null)
        {
            // TODO: filter department by approver permissions before calling export
            var bytes = await _excelService.ExportEmployeesToExcelAsync(department);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "employees.xlsx");
        }
    }

}
