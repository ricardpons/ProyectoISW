using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EcoScooter.Entities
{
    public partial class Employee : Person
    {
        public Employee() : base()
        {
            Maintenances = new List<Maintenance>();
        }
        public Employee(DateTime birthDate, String dni, String email, String
       name, int telephon, String iban, int pin, String position, Decimal salary) :
       base(birthDate, dni, email, name, telephon)
        {

            Iban = iban;
            Pin = pin;
            Position = position;
            Salary = salary;
            Maintenances = new List<Maintenance>();
        }
    }
}