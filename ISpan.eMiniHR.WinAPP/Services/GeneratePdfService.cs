using ISpan.eMiniHR.DataAccess.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;

namespace ISpan.eMiniHR.WinApp.Services
{
    public class GeneratePdfService : IDocument
    {
        private readonly EmployeeDto _emp;
        private readonly string _imgPath;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="emp"></param>
        public GeneratePdfService(EmployeeDto emp, string imgPath)
        {
            _emp = emp;
            _imgPath = imgPath;
        }

        //return DocumentMetadata.Default  // 預設中繼資訊
        public DocumentMetadata GetMetadata() => new DocumentMetadata
        {
            Title = "人事資料表",
            Author = "eMiniHR 系統",
            Subject = "員工資料列印"
        };

        // 主排版方法
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(x => x.FontFamily("Microsoft JhengHei").FontSize(12)); // 中文支援！

                page.Header().Text("人事基本資料表")
                    .FontSize(20)
                    .SemiBold()
                    .FontColor(Colors.Blue.Darken2);

                page.Content().Table(table =>
                {
                    // 欄位定義
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(80); 
                        columns.RelativeColumn();
                        columns.ConstantColumn(80);
                        columns.RelativeColumn();
                        columns.ConstantColumn(80);
                        columns.RelativeColumn();
                    });

                    table.Cell().Element(CellStyle).Text("姓名");
                    table.Cell().Element(CellStyle).Text(_emp.EmpNm);

                    table.Cell().Element(CellStyle).Text("到職年月日");
                    table.Cell().Element(CellStyle).Text(_emp.HireDate?.ToString("yyyy/MM/dd") ?? "");

                    /*
                     名稱空間	用途
                        QuestPDF.Fluent	提供 .Text(), .Image() 等 fluent 接口
                        QuestPDF.Infrastructure	提供 IDocument, IContainer 等基礎架構
                        QuestPDF.Drawing	✅ Image.FromFile(), Image.FromStream() 所在命名空間
                     */

                    var imageData = LoadImageData(_imgPath);
                    if (imageData != null)
                    {
                        table.Cell().ColumnSpan(2).RowSpan(4)
                            .AlignCenter().AlignMiddle().Height(100)
                            .Image(imageData, ImageScaling.FitArea);
                    }
                    else
                    {
                        table.Cell().ColumnSpan(1).RowSpan(3)
                            .AlignCenter().AlignMiddle().Height(100)
                            .Text("無照片").FontSize(10).Italic();
                    }

                    table.Cell().ColumnSpan(1).Element(CellStyle).Text("通訊地址");
                    table.Cell().ColumnSpan(3).Element(CellStyle).Text(_emp.Address_Contact);

                    /*
                     void AddRow(string label, string value, bool alignRight = false)
                        {
                            table.Cell().Element(CellStyle).Text(label);
                            var cell = table.Cell().Element(CellStyle).Text(value);
                            if (alignRight) cell.AlignRight();
                        }

                     AddRow("員工編號", _emp.EmpId);
                    AddRow("部門", _emp.DepName);
                    AddRow("Email", _emp.Email);
                    AddRow("", $"列印時間    {DateTime.Now:yyyy/MM/dd HH:mm}", alignRight: true);

                     
                     */

                    //// 列的格式
                    //void AddRow(string label, string value, bool alignRight = false)
                    //{
                    //    //table.Cell().Element(CellStyle).Text(label).FontSize(12);
                    //    //table.Cell().Element(CellStyle).Text(value).FontSize(12);

                    //    table.Cell().Element(CellStyle).Text(label).FontSize(12);

                    //    var content = table.Cell().Element(CellStyle).Text(value).FontSize(12);
                    //    if (alignRight) content.AlignRight(); // 靠右顯示
                    //}

                    //// 這一行會靠右
                    //AddRow("", $"列印時間    {DateTime.Now.ToString("yyyy/MM/dd HH:mm")}", alignRight: true);

                    //AddRow("員工編號", _emp.EmpId);
                    //AddRow("姓名", _emp.EmpNm);
                    //AddRow("部門", _emp.DepName);
                    //AddRow("職稱", _emp.JobLevel);
                    //AddRow("生日", _emp.BirthDate?.ToString("yyyy/MM/dd") ?? "");
                    //AddRow("Email", _emp.Email);

                    // 新增一列：跨兩欄的備註
                    table.Cell().ColumnSpan(2)
                        .Element(CellStyle)
                        .Text("※ 本資料為機密使用，未經授權不得外流。")
                        .FontSize(10)
                        .Italic();

                    // 表格樣式 + 分隔線
                    static IContainer CellStyle(IContainer container) =>
                        container.PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                });

                // 頁尾
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("頁尾 - Confidential").FontSize(10);
                });
            });
        }

        private static byte[] LoadImageData(string path)
        {
            return File.Exists(path) ? File.ReadAllBytes(path) : null;
        }
    }
}