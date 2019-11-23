using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class EcoScooter
    {

        public EcoScooter()
        {
            Employees = new List<Employee>();
            People = new List<Person>();
            Scooters = new List<Scooter>();
            Stations = new List<Station>();
        }

        public EcoScooter(double DiscountYounger, double Fare, double MaxSpeed)
        {

            this.DiscountYounger = DiscountYounger;
            this.Fare = Fare;
            this.MaxSpeed = MaxSpeed;

            Employees = new List<Employee>();
            People = new List<Person>();
            Scooters = new List<Scooter>();
            Stations = new List<Station>();

            // Employees.Add(employee);

        }

        public void addPerson(Person p)
        {

           

        }
    }
}
