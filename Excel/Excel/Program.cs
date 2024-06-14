using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.OleDb;

// Definiowanie połączenia z plikiem Excel
string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ścieżka_do_pliku.xls;Extended Properties='Excel 8.0;'";

// Tworzenie zapytania SQL do odczytu danych
string query = "SELECT * FROM [NazwaArkusza$]";

// Tworzenie obiektu OleDbConnection i otwieranie połączenia
using (OleDbConnection connection = new OleDbConnection(connectionString))
{
    connection.Open();

    // Tworzenie obiektu OleDbCommand i przypisanie zapytania SQL i połączenia
    using (OleDbCommand command = new OleDbCommand(query, connection))
    {
        // Tworzenie obiektu OleDbDataReader i wykonanie zapytania
        using (OleDbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                // Przykładowe użycie danych odczytanych z pliku Excel
                string wartośćKolumny1 = reader.GetString(0);
                int wartośćKolumny2 = reader.GetInt32(1);

                // Można tutaj robić coś z odczytanymi danymi, np. zapisywać w innej formie lub wyświetlać na ekranie
            }
        }
    }
}