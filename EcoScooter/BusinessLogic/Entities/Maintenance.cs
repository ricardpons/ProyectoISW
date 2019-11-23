using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EcoScooter.Entities
{
    public partial class Maintenance
    {
        public Maintenance()
        {
            PlanningWork = new List<PlanningWork>();
        }
        public Maintenance(String description, DateTime? endDate, DateTime startDate, Employee employee) : this()
        {
            Description = description;
            EndDate = endDate;
            StartDate = startDate;
            Employee = employee;
        }
    }
}