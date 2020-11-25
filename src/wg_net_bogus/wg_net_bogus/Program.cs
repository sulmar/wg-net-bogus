using ConsoleTables;
using System;
using System.Collections.Generic;

namespace wg_net_bogus
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcome();

            // GenerateCustomersTest();

            // GenerareMeasuresTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

      

        private static void GenerateCustomersTest()
        {
            var customers = new List<Customer>
            {

            };

            ConsoleTable
               .From(customers)
               .Configure(o => o.NumberAlignment = Alignment.Left)
               .Write(Format.Alternative);
        }


        private static void GenerareMeasuresTest()
        {
        }




        private static void DisplayWelcome()
        {
            var table = new ConsoleTable("col1", "col2", "col3");

            table
                 .AddRow("WGdotNET", "139. Spotkanie", "Udawanie danych z Bogusiem!")
                 .AddRow("Marcin Sulecki", "marcin.sulecki@sulmar.pl", "github.com/sulmar");

            table.Write(Format.Alternative);
            Console.WriteLine();
        }
    }


    #region Models
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Description { get; set; }
        public decimal? CreditAmount { get; set; }
        public string Pesel { get; set; }
        public bool IsRemoved { get; set; }
    }

    public enum Gender
    {
        Female,
        Male
    }

    public enum CustomerType
    {
        Smiling,
        Nervous,
        Troublesome,
        Serious
    }

    public class Sensor
    {
        public string MacAddress { get; set; }
        public string Name { get; set; }

    }

    public class Measure
    {
        public Guid Id { get; set; }
        public Sensor Sensor { get; set; }
        public float Value { get; set; }
    }

    #endregion

    public static class MeasureExtensions
    {
        public static void Dump(this Measure measure)
        {
            Console.WriteLine($"{DateTime.Now} {measure.Sensor.MacAddress} {measure.Sensor.Name} {measure.Value}");
        }
    }


}
