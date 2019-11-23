using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class Scooter
    {

        public int ID
        {
            get;
            set;

        }

        public DateTime RegisterDate
        {
            get;
            set;


        }


        public ScooterState State
        {
            get;
            set;


        }
        public ICollection<PlanningWork> planningWorks
        {
            get; set;
        }
        public ICollection<Rental> rentals
        {
            get;
            set;


        }
        public Station station
        {
            get;
            set;
        }
        public Maintenance maintenance
        {
            get;
            set;
        }
        public EcoScooter ecoScooter
        {
            get;
            set;
        }
    }
}
