using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class PlanningWork
    {

        [Key]
        public String name
        {
            get;
            set;
        }

        public String Description
        {
            get;
            set;
        }

        public int WorkingTime
        {
            get;
            set;
        }

        public Scooter scooter
        {
            get;
            set;
        }

        public Maintenance maintenance
        {
            get;
            set;
        }
    }
}
