using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoScooter.Entities;
using EcoScooter.Persistence;


namespace PruebaLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EntityFrameworkDAL dal = new EntityFrameworkDAL(new EcoScooterDbContext());

                new Program(dal);


            }
            catch (Exception e)
            {
                printError(e);
                Console.WriteLine("Press any key.");
                Console.ReadLine();
            }

        }

        public Program(IDAL dal)
        {
            createSampleDB(dal);
            Console.WriteLine("\n\n\n");
            displayData(dal);
        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }

        private void createSampleDB(IDAL dal)
        {
            // Remove all data from DB
            dal.RemoveAllData();

            // Populate the database with data
            Employee e = new Employee(DateTime.Parse("19/10/2000"), "20123123A", "correo@mail.com", "Rodolfo Valentino", 96123123, "ES651234567890", 1234, "Vertical", 3000);
            dal.Insert<Employee>(e);
            dal.Commit();

            EcoScooter.Entities.EcoScooter ecoscooter;
            ecoscooter = new EcoScooter.Entities.EcoScooter(5, 10, 30, e);
            dal.Insert<EcoScooter.Entities.EcoScooter>(ecoscooter);
            dal.Commit();

            // ... more objects ...
        }

        private void displayData(IDAL dal)
        {

            Console.WriteLine("===================================");
            Console.WriteLine("         EcoScooter details        ");
            Console.WriteLine("===================================");

            EcoScooter.Entities.EcoScooter ecoscooter;
            ecoscooter = dal.GetAll<EcoScooter.Entities.EcoScooter>().First();
            Console.WriteLine("MaxSpeed: " + ecoscooter.MaxSpeed + ", fare = " + ecoscooter.Fare);

            Console.WriteLine("Pres Key to exit...");
            Console.ReadKey();

            Console.WriteLine("===================================");
            Console.WriteLine("         Employee details          ");
            Console.WriteLine("===================================");

            foreach (Employee e in ecoscooter.Employees)
            {
                Console.WriteLine(employeeToString(e));
            }

            Console.WriteLine("Pres Key to exit...");
            Console.ReadKey();

        }

        public String employeeToString(Employee e)
        {
            return "  Name: " + e.Name + " dni: " + e.Dni + " email: " + e.Email;
        }

    }
}
