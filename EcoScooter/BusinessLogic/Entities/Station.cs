using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class Station
    {
        private readonly Scooter anchor;

        public Station ()
        {
            DestinationRentals = new List<Rental>();
            OriginRental = new List<Rental>();
            anchors = new List<Scooter>();
        }
    public Station(String Address, String Id, double Latitude, double Longitude)
    {
        this.Address = Address;
        this.Id = Id;
        this.Latitude = Latitude;
        this.Longitude = Longitude;

        DestinationRentals = new List<Rental>();
        OriginRental = new List<Rental>();
        anchors = new List<Scooter>();

     }
}
}
