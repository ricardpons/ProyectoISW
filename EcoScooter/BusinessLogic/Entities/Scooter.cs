using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class Scooter
    {
        public Scooter()
        {
            planningWorks = new List<PlanningWork>();
            rentals = new List<Rental>();
        }
        public Scooter(int ID, DateTime RegisterDate, ScooterState State)
        {
            this.ID = ID;
            this.RegisterDate = RegisterDate;
            this.State = State;

            planningWorks = new List<PlanningWork>();
            rentals = new List<Rental>();

        }
    }
}
