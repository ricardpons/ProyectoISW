using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class Rental
    {

        public Rental ()
        {
            TrackPoints = new List<TrackPoint>();
        }

        public Rental (DateTime? EndDate,  double Price, DateTime StartDate, Station origin, Scooter scooter, User user)
        {
            this.EndDate = EndDate;
            
            this.Price = Price;
            this.StartDate = StartDate;

            this.origin = origin;
            this.scooter = scooter;
            TrackPoints = new List<TrackPoint>();
            this.user = user;

        }
    }
}
