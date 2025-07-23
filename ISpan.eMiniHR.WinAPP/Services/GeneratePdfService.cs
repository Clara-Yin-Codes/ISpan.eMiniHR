using ISpan.eMiniHR.DataAccess.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

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
                page.DefaultTextStyle(x => x.FontFamily("Microsoft JhengHei").FontSize(13.5f)); // 支援中文

				page.Header().Text("eMiniHR  人事基本資料表")
                    .LineHeight(2)
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
                        columns.ConstantColumn(120);
                    });

                    table.Cell().ColumnSpan(2).AlignLeft().Text($" 部門: {_emp.DepName}");
                    table.Cell().ColumnSpan(3).AlignRight().Text($"到職日期: {_emp.HireDate?.ToString("yyyy/MM/dd")}");

                    table.Cell().Element(CellStyle).Text(" 姓名");
                    table.Cell().Element(CellStyle).Text(" " + _emp.EmpNm);

					table.Cell().Element(CellStyle).Text(" 員工編號");
					table.Cell().Element(CellStyle).Text(" " + _emp.EmpId);

                    /*
                     名稱空間	用途
                        QuestPDF.Fluent	提供 .Text(), .Image() 等 fluent 接口
                        QuestPDF.Infrastructure	提供 IDocument, IContainer 等基礎架構
                        QuestPDF.Drawing	✅ Image.FromFile(), Image.FromStream() 所在命名空間
                     */

                    var imageData = LoadImageData(_imgPath);
                    if (imageData != null)
                    {
                        table.Cell().RowSpan(7)
                            .AlignCenter().AlignMiddle().Height(90)
                            .Image(imageData, ImageScaling.FitArea);

                        //table.Cell().ColumnSpan(2).RowSpan(6)
                        //    .AlignCenter().AlignMiddle()
                        //    .Height(180)
                        //    .Image(imageData, ImageScaling.FitArea);
                    }
                    else
                    {
                        table.Cell().RowSpan(7)
                            .AlignCenter().AlignMiddle().Height(90)
                            .Text("無照片").FontSize(10).Italic();
                    }

					table.Cell().Element(CellStyle).Text(" 身分證字號");
					table.Cell().Element(CellStyle).Text($" {_emp.IdNumber}");

					table.Cell().Element(CellStyle).Text(" 年齡");
					table.Cell().Element(CellStyle).Text(" " + _emp.Age.ToString());

					table.Cell().Element(CellStyle).Text(" 性別");
                    var gender = _emp.GenderM ? "男" : "女";
					table.Cell().Element(CellStyle).Text($" {gender}");

					table.Cell().Element(CellStyle).Text(" 外國籍");
					var isForeign = _emp.IsForeign ? "是" : "否";
					table.Cell().Element(CellStyle).Text($" {isForeign}");

					table.Cell().Element(CellStyle).Text(" 出生年月日");
                    table.Cell().Element(CellStyle).Text(" " + _emp.BirthDate?.ToString("yyyy/MM/dd") ?? "");

					table.Cell().Element(CellStyle).Text(" 已婚");
					var isMarried = _emp.IsMarried != null && _emp.IsMarried == true ? "是" : "否";
					table.Cell().Element(CellStyle).Text($" {isMarried}");

                    table.Cell().Element(CellStyle).Text(" 聯絡電話");
                    table.Cell().Element(CellStyle).Text(" " + _emp.Tel);

                    table.Cell().Element(CellStyle).Text(" 緊急聯絡人");
                    table.Cell().Element(CellStyle).Text(" " + _emp.EmergencyContact);

					table.Cell().Element(CellStyle).Text(" 參加福利會");
					var isWelfareMember = _emp.IsWelfareMember != null && _emp.IsWelfareMember == true ? "是" : "否";
					table.Cell().Element(CellStyle).Text(" " + isWelfareMember);

					table.Cell().Element(CellStyle).Text(" 班別");
					table.Cell().Element(CellStyle).Text(" " + _emp.ShiftName);

					table.Cell().Element(CellStyle).Text(" 職等");
					table.Cell().Element(CellStyle).Text(" " + _emp.JobLevelName);

					table.Cell().Element(CellStyle).Text(" 員工類別");
					table.Cell().Element(CellStyle).Text(" " + _emp.EmployeeTypeName);

					table.Cell().Element(CellStyle).Text(" 直屬主管");
					table.Cell().Element(CellStyle).Text(" " + _emp.MgrIdName);

					table.Cell().Element(CellStyle).Text(" 電子郵件");
					table.Cell().ColumnSpan(2).Element(CellStyle).Text(" " + _emp.Email);

					table.Cell().Element(CellStyle).Text(" 員工薪資");
                    table.Cell().Element(CellStyle).Text(" " + _emp.CustomSalary);

					table.Cell().Element(CellStyle).Text(" 戶籍地址");
					table.Cell().ColumnSpan(2).Element(CellStyle).Text(" " + _emp.Address_Registered);

					table.Cell().Element(CellStyle).Text("");
					table.Cell().Element(CellStyle).Text("");

					table.Cell().Element(CellStyle).Text(" 通訊地址");
					table.Cell().ColumnSpan(2).Element(CellStyle).Text(" " + _emp.Address_Contact);

					table.Cell().Element(CellStyle).Text(" 離職日");
					table.Cell().Element(CellStyle).Text(" " + _emp.ResignDate?.ToString("yyyy/MM/dd") ?? "");

					table.Cell().Element(CellStyle).Text(" 離職原因");
					table.Cell().ColumnSpan(2).Element(CellStyle).Text(" " + _emp.ResignReason);

					table.Cell().Element(CellStyle).Text(" 備註");
					table.Cell().ColumnSpan(4).Element(CellStyle).Text(" " + _emp.Memo);

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().ColumnSpan(2).Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().ColumnSpan(2).Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().ColumnSpan(2).Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().ColumnSpan(2).Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().Element(CellStyle).Text("");

					//table.Cell().Element(CellStyle).Text("");
					//table.Cell().ColumnSpan(2).Element(CellStyle).Text("");



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
					table.Cell().ColumnSpan(4)
                        .Text("※ 本資料為機密使用，未經授權不得外流。")
                        .FontSize(10)
                        .Italic();

                    // 表格樣式 + 分隔線
                    static IContainer CellStyle(IContainer container) =>
                        container
                            .MinHeight(15)
                            .AlignMiddle()
                            .Border(0.8f)
                            .BorderColor(Colors.Grey.Darken2);
                });

                // 頁尾
                page.Footer().AlignRight().Text(x =>
                {
                    x.Span($"列印日期: {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}").FontSize(10);
                });
            });
        }

        private static byte[] LoadImageData(string path)
        {
            return File.Exists(path) ? File.ReadAllBytes(path) : null;
        }
    }
}