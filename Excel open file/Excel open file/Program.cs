using OfficeOpenXml;
using System;
using System.IO;

string inputString = "DB111.DBW10";

string lastThreeDigits = inputString.Substring(inputString.Length - 2);

//Następnie, aby przekształcić odczytane cyfry w liczbę całkowitą, możemy użyć metody "Parse" klasy "Int32":

int lastThreeDigitsInt = Int16.Parse(lastThreeDigits);

//Jeśli chcemy ponownie zmienić tę liczbę całkowitą na ciąg znaków, możemy użyć metody "ToString":

string lastThreeDigitsString = lastThreeDigitsInt.ToString();

Console.WriteLine(lastThreeDigitsInt);

Console.WriteLine(lastThreeDigitsString);






//string filePath = "C:\\Users\\PGM61\\Desktop\\Pass_Operators\\Data.xlsx";
//var fileInfo = new FileInfo(filePath);

//using (var package = new ExcelPackage(fileInfo))
//{
//    var worksheet = package.Workbook.Worksheets[1]; // Arkusz pierwszy

// Odczytaj wartości z pierwszych trzech wierszy
//    for (int row = 1; row <= 3; row++)
//    {
//        for (int column = 1; column <= worksheet.Dimension.Columns; column++)
//       {
//            string cellValue = worksheet.Cells[2,1].Value?.ToString();

//            string liczbas = cellValue;
//            int liczba = Convert.ToInt16(liczbas);

// Przetwarzaj wartość komórki, np. wyświetl ją na konsoli
//           Console.WriteLine(liczba);
//       }
//   }
//}

//using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
//{
//    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

//    int rowNumber = 3; // Numer wiersza, z którego chcesz odczytać liczby.
//    int columnNumber = 1; // Numer kolumny, z której chcesz odczytać liczby.

//    int result;
//    if (int.TryParse(worksheet.Cells[rowNumber, columnNumber].Value?.ToString(), out result))
//   {
//       Console.WriteLine($"Odczytana liczba to: {result}");
//   }
//   else
//   {
//        Console.WriteLine("Nie udało się odczytać liczby.");
//    }
//}
