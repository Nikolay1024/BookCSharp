using System;
using System.Collections.Generic;
// Создать псевдоним для объектной модели Excel.
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    class Program
    {
        static void Main()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Color = "Green", Make = "VW", Name = "Mary" },
                new Car { Color = "Red", Make = "Saab", Name = "Mel" },
                new Car { Color = "Black", Make = "Ford", Name = "Hank" },
                new Car { Color = "Yellow", Make = "BMW", Name = "Davie" }
            };
            ExportToExcel(cars);
            Console.ReadKey();
        }

        static void ExportToExcel(List<Car> cars)
        {
            // Загрузить Excel и затем создать новую пустую рабочую книгу.
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            // Сделать пользовательский интерфейс Excel видимым на рабочем столе.
            excelApp.Visible = true;
            // В этом примере используется единственный рабочий лист.
            Excel._Worksheet worksheet = excelApp.ActiveSheet;
            // Установить заголовки столбцов в ячейках.
            worksheet.Cells[1, "A"] = "Make";
            worksheet.Cells[1, "B"] = "Color";
            worksheet.Cells[1, "C"] = "Name";
            // Отобразить все данные из List<Car> на ячейки электронной таблицы.
            int row = 1;
            foreach (Car car in cars)
            {
                row++;
                worksheet.Cells[row, "A"] = car.Make;
                worksheet.Cells[row, "B"] = car.Color;
                worksheet.Cells[row, "C"] = car.Name;
            }
            // Придать симпатичный вид табличным данным.
            worksheet.Range["A1"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            // Сохранить файл, завершить работу Excel и отобразить сообщение пользователю.
            worksheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("Файл Inventory.xslx сохранен в папке приложения.");
        }
    }
}
