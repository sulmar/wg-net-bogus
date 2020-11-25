using ConsoleTables;
using System;
using System.Collections.Generic;

namespace wg_net_bogus
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.DisplayWelcome();

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


            // dotnet add package ConsoleTables
            ConsoleTable
               .From(customers)
               .Configure(o => o.NumberAlignment = Alignment.Left)
               .Write(Format.Alternative);
        }


        private static void GenerareMeasuresTest()
        {
        }
    }



    #region Customer Model

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

    #endregion

    #region Measure Model

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

    public static class MeasureExtensions
    {
        public static void Dump(this Measure measure)
        {
            Console.WriteLine($"{DateTime.Now} {measure.Sensor.MacAddress} {measure.Sensor.Name} {measure.Value}");
        }
    }

#endregion

}
