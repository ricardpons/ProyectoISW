using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoScooter.Entities;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e;
            e = new Employee(DateTime.Parse("19/10/2000"), "20123123A", "correo@mail.com", "Rodolfo Valentino", 96123123, "ES651234567890", 1234, "Vertical", 3000);
            Console.WriteLine("Nombre del empleado: " + e.Name);

            EcoScooter.Entities.EcoScooter ecoScooter;
            ecoScooter = new EcoScooter.Entities.EcoScooter(5, 10, 30);

            ecoScooter.Employees.Add(e);
            Console.WriteLine("Nombre del primer empleado: " + ecoScooter.Employees.First().Name);
            Console.ReadLine();
       }
    }
}
