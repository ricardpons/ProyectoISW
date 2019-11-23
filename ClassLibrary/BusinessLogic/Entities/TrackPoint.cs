using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class TrackPoint
    {
        public TrackPoint()
        {

        }
        public TrackPoint(String name, double BatteryLevel, double Lattitude, double Longitude, double Speed, DateTime Timestamp)
        {
            this.name = name;
            this.BatteryLevel = BatteryLevel;
            this.Lattitude = Lattitude;
            this.Longitude = Longitude;
            this.Speed = Speed;
            this.Timestamp = Timestamp;


        }

    }
}
