using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Persistence
{
    public partial class TrackPoint
    {
        [key]
        public String name
        {
            get;
            set;
        }

        public double BatteryLevel
        {
            get;
            set;
        }
        public double Lattitude
        {
            get;
            set;
        }
        public double Longitude {
            get;
            set;
        }
        public double Speed
        {
            get;
            set;
        }
        public DateTime Timestamp
        {
            get;
            set;
        }
        public Rental rental
        {
            get;
            set;
        }
    }
}
