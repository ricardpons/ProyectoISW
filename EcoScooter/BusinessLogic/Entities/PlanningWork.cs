using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class PlanningWork
    {
        public PlanningWork()
        {
            

        }

        public PlanningWork(String descrption,int WorkingTime,Maintenance man,Scooter scot)
            {
            this.Description = descrption;
            this.WorkingTime = WorkingTime;
            this.maintenance=man;
            this.scooter=scot;



            }


    }
}
