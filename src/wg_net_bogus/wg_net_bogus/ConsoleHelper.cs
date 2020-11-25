using ConsoleTables;
using System;

namespace wg_net_bogus
{
    public static class ConsoleHelper
    {
        public static void DisplayWelcome()
        {
            // dotnet add package ConsoleTables
            var table = new ConsoleTable("col1", "col2", "col3");

            table
                 .AddRow("WGdotNET", "139. Spotkanie", "Udawanie danych z Bogusiem!")
                 .AddRow("Marcin Sulecki", "marcin.sulecki@sulmar.pl", "github.com/sulmar");

            table.Write(Format.Alternative);
            Console.WriteLine();
        }
    }

}
