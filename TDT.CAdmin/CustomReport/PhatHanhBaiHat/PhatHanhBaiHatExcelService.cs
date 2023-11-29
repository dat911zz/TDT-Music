using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using TDT.Core.DTO.Firestore;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.IService;
using TDT.Core.Ultils;

namespace TDT.CAdmin.CustomReport.PhatHanhBaiHat
{
    public class PhatHanhBaiHatExcelService : IExcel
    {
        private readonly int DETAIL_BEGINROW = 7;
        private int row;
        private ExcelWorksheet excelWorkSheet;
        TypeRelease type;
        string tempFilePath;
        public PhatHanhBaiHatExcelService(TypeRelease type, string tempFilePath)
        {
            this.type = type;
            this.tempFilePath = tempFilePath;
        }

        public byte[] GetExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(tempFilePath), true))
            {
                row = DETAIL_BEGINROW;
                this.excelWorkSheet = excelPackage.Workbook.Worksheets[0];
                WriteExcel();
                return excelPackage.GetAsByteArray();
            }
        }

        private void WriteExcel()
        {
            GenerateReport();
            this.excelWorkSheet.Cells["B4"].Value = "[01] Ngày báo cáo: " + DateTime.UtcNow.ToString("dd/MM/yyyy");
            string modelRange = "B" + DETAIL_BEGINROW + ":J" + (this.row - 1);
            var modelTable = excelWorkSheet.Cells[modelRange];
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            excelWorkSheet.Cells.Style.Font.Name = "Times New Roman";
        }

        private void GenerateReport()
        {

            List<SongDTO> songs = null;
            if (type == TypeRelease.VietNam)
            {
                songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}/LoadSongReleaseVN");
            }
            else
            {
                songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}/LoadSongReleaseAll");
            }
            List<object[]> dataReports = new List<object[]>();
            if (songs.Count > 0)
            {
                int index_invoice = 1;
                foreach (var song in songs)
                {
                    WriteDetailsExcelRow(index_invoice++, song, ref dataReports);
                }
            }
            if (dataReports.Count > 0)
            {
                var range = excelWorkSheet.Cells[DETAIL_BEGINROW, 2];
                range.LoadFromArrays(dataReports);
            }
        }

        private void WriteDetailsExcelRow(int v, SongDTO song, ref List<object[]> dataReports)
        {
            object[] dataReport = new object[] {
                v,
                song.encodeId,
                song.title,
                song.ReleaseDate().ToString("dd/MM/yyyy"),
                song.artistsNames,
                song.listen,
                song.like,
                song.streamingStatus > 0 ? "Có file MP3" : "Không có file MP3",
                ""
            };
            dataReports.Add(dataReport);
            row++;
        }
    }
}
