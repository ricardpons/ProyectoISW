using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Persistence
{
    public partial class Rental
    {
        public DateTime? EndDate
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }


        public double Price
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        /*Relaciones*/
        public User user
        {
            get;
            set;
        }

        [InverseProperty("OriginRentals")]
        public Station origin
        {
            get;
            set;
        }

        [InverseProperty("DestinationRentals")]
        public Station destination
        {
            get;
            set;
        }

        public ICollection<TrackPoint> TrackPoints
        {
            get;
            set;
        }

        public Incident incident
        {
            get;
            set;
        }

        public Scooter scooter
        {
            get;
            set;
        }
    }
}
