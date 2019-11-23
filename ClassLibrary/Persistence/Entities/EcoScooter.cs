using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class EcoScooter
    {

        public double DiscountYounger
        {
            get;
            set;
        }

        [Key]
        public String name
        {
            get;
            set;
        }

        public double Fare
        {
            get;
            set;
        }

        public double MaxSpeed
        {
            get;
            set;
        }

        /*Relaciones*/
        public virtual ICollection<Employee> Employees
        {
            get;
            set;
        }
        public virtual ICollection<Person> People
        {
            get;
            set;
        }
        public virtual ICollection<Scooter> Scooters
        {
            get;
            set;
        }
        public virtual ICollection<Station> Stations
        {
            get;
            set;
        }
    }
}
