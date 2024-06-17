using System.Collections.Generic;
using System.Windows;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Core.ExcelPackage;
using System.ComponentModel;
using Olimp.Model;
using System.Linq;
using System;

namespace Olimp.View.Prepodovatiel
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : System.Windows.Controls.Page
    {
        Core db = new Core();
        public ReportPage()
        {
            InitializeComponent();
        }
        public class Participant
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public string Result { get; set; }
        }
        
        private void GenerateReport(object sender, RoutedEventArgs e)
        {

            if (Names.Text !="")
            {
                string absolutePath = Path.GetFullPath(@"..\..\..\..\course-work\Olimp\src\diplomas"); 

                string filePaths = Path.Combine(absolutePath, Names.Text + ".xlsx");
               // MessageBox.Show(db.context.Results.Count().ToString());
                if (!File.Exists(filePaths))
                {
                    var participants = new List<Participant>();
                    int i = 1;
                    int j = 1;
                    do  
                    {


                        var zxc = db.context.Results.FirstOrDefault(u => u.id == j);

                        try
                        {
                            if (zxc.student_id != null)
                            {
                                int studentId = int.Parse(zxc.student_id.ToString());
                                // MessageBox.Show(studentId.ToString());
                                participants.Add(new Participant
                                {
                                    Name = db.context.Students
                                    .Where(u => u.StudentID == studentId)
                                    .Select(u => u.FullName)
                                    .FirstOrDefault(),
                                    Score = int.Parse(zxc.score.ToString()),
                                    Result = zxc.result
                                });
                                i++;
                                j++;
                            }
                        }
                        catch {
                            j++;
                        }
                    }
                    while (i-1 < db.context.Results.Count());
                    string filenamess =Names.Text+".xlsx";
                    //MessageBox.Show(filenamess);
                    CreateExcelDocument(filenamess, participants);
                    MessageBox.Show("Успех");
                }
                else
                {
                    MessageBox.Show("Файл с таким именем уже существует");
                }
                
            }
            else
            {
                MessageBox.Show("Не введено имя файла");
            }
        }
        public static void CreateExcelDocument(string fileName, List<Participant> participants)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Olympiad Results");

                // Устанавливаем значения в ячейки
                worksheet.Cells[2, 2].Value = "Имя участника";
                worksheet.Cells[2, 3].Value = "Количество балов";
                worksheet.Cells[2, 4].Value = "Результат";

                // Устанавливаем границы для заголовков столбцов
                worksheet.Cells["B2:D2"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells["B2:D2"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells["B2:D2"].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells["B2:D2"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                for (int i = 0; i < participants.Count; i++)
                {
                    worksheet.Cells[i + 3, 2].Value = participants[i].Name;
                    worksheet.Cells[i + 3, 3].Value = participants[i].Score;
                    worksheet.Cells[i + 3, 4].Value = participants[i].Result;

                    // Устанавливаем границы для текущей строки
                    worksheet.Cells[i + 3, 2, i + 3, 4].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells[i + 3, 2, i + 3, 4].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells[i + 3, 2, i + 3, 4].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells[i + 3, 2, i + 3, 4].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                }
                string currentDirectory = Environment.CurrentDirectory;
                string relativePath = @"..\..\..\..\course-work\Olimp\src\diplomas";

                string absolutePath = Path.GetFullPath(relativePath);
                string filePath = Path.Combine(absolutePath, fileName);
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
