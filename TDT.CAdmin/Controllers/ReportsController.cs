using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TDT.CAdmin.CustomReport.PhatHanhBaiHat;
using TDT.CAdmin.Models;
using TDT.Core.Models;

namespace TDT.CAdmin.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        public IActionResult BaiHatVuaPhatHanh()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BaiHatVuaPhatHanh(int typeRelease)
        {
            string tempFilePath = AppDomain.CurrentDomain.BaseDirectory + "CustomReport/Template/PhatHanhBaiHat.xlsx";
            PhatHanhBaiHatExcelService service = new PhatHanhBaiHatExcelService((Core.Enums.TypeRelease)typeRelease, tempFilePath);
            byte[] excel = service.GetExcel();
            return this.File(excel, "application/vnd.ms-excel", "ReportBaiHatVuaPhatHanh.xlsx");
        }
    }
}
