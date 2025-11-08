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
            var (inserted, skipped) = await _excelService.ImportTblEmpLogFromExcelAsync(stream);

            TempData["Message"] = $"Inserted: {inserted}, Skipped: {skipped}";
            return RedirectToAction("Upload");
        }

    }

}
