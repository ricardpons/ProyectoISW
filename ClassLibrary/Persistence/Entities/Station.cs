using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class Station
    {

        public String Address
        {
            get;
            set;
        }

        public String Id
        {
            get;
            set;
        }

        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }

        public ICollection<Rental> DestinationRentals
        {
            get;
            set;
        }

        public ICollection<Rental> OriginRental
        {
            get;
            set;
        }

        public ICollection<Scooter> anchors
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
