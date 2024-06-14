using OfficeOpenXml;
using System.IO;

string filePath = "Data.xls";
var fileInfo = new FileInfo(filePath);

using (ExcelPackage package = new ExcelPackage(fileInfo))
{
    var worksheet = package.Workbook.Worksheets[1]; // Arkusz pierwszy

    // Odczytaj wartości z pierwszych trzech wierszy
    for (int row = 1; row <= 3; row++)
    {
        for (int column = 1; column <= worksheet.Dimension.Columns; column++)
        {
            string cellValue = worksheet.Cells[row, column].Value?.ToString();
            // Przetwarzaj wartość komórki, np. wyświetl ją na konsoli
            Console.WriteLine(cellValue);
        }
    }
}
