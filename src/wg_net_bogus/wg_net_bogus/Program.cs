using Bogus;
using Bogus.Extensions;
using ConsoleTables;
using System;
using System.Collections.Generic;
using Bogus.Extensions.Poland;
using System.Threading;

namespace wg_net_bogus
{
    class Program
    {
        static void Main(string[] args)
        {
           // GenerateCustomersTest();
             GenerareMeasuresTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

   

        // dotnet add package Bogus

        private static void GenerateCustomersTest()
        {
            CustomerFaker customerFaker = new CustomerFaker();

            var customers = customerFaker.Generate(100);


            // dotnet add package ConsoleTables
            ConsoleTable
               .From(customers)
               .Configure(o => o.NumberAlignment = Alignment.Left)
               .Write(Format.Alternative);
        }


        private static void GenerareMeasuresTest()
        {
            var sensors = new Faker<Sensor>()
                .RuleFor(p => p.MacAddress, f => f.Internet.Mac())
                .RuleFor(p => p.Name, f => f.Hacker.Noun())
                .Generate(10);

            var meaures = new Faker<Measure>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Value, f => f.Random.Float(0f, 100f))
                .RuleFor(p => p.Sensor, f => f.PickRandom(sensors))
                .GenerateForever();
               

            foreach(var measure in meaures)
            {
                measure.Dump();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }




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

    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Gender, f => (Gender)f.Person.Gender);
            RuleFor(p => p.Birthday, f => f.Person.DateOfBirth);
            RuleFor(p => p.Email, (f,c) => $"{c.FirstName}.{c.LastName}@domain.com");
            RuleFor(p => p.CustomerType, f => f.PickRandom<CustomerType>());
            RuleFor(p => p.Description, f => f.Lorem.Sentence(1));
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));
            RuleFor(p => p.CreditAmount, f => f.Random.Decimal(1m, 1000m).OrNull(f, 0.2f));
            RuleFor(p => p.Pesel, f => f.Person.Pesel());


        }
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
