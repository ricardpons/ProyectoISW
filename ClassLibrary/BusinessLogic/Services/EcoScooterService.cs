using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoScooter.Entities;
using EcoScooter.Persistence;

namespace EcoScooter.Services
{
    class EcoScooterService : IEcoScooterService
    {

        private EntityFrameworkDAL dal;
        private User loggedMember;

        private double fare;
        private double discountYounger;
        private double maxSpeed;

        public EcoScooterService(EntityFrameworkDAL entityFrameworkDAL)
        {
            this.dal = entityFrameworkDAL;
            try
            {
                this.fare = dal.GetAll<EcoScooter.Entities.EcoScooter>().First().Fare;
                this.discountYounger = dal.GetAll<EcoScooter.Entities.EcoScooter>().First().DiscountYounger;
                this.maxSpeed = dal.GetAll<EcoScooter.Entities.EcoScooter>().First().MaxSpeed;
            }
            catch (Exception)
            {
                
            }
            this.loggedMember = null;
        }

        public void GetRouteDescription(int rentalId, out DateTime startDate, out DateTime endDate, out decimal price, out int originStationId, out int destinationStationId)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetUserRoutes(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetUserRoutesIds(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public bool isLoggedAsEmployee(string dni)
        {
            throw new NotImplementedException();
        }

        public bool isLoggedAsUser(string dni)
        {
            throw new NotImplementedException();
        }

        public void LoginEmployee(string dni, int pin)
        {
            throw new NotImplementedException();
        }

        public void LoginUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void RegisterIncident(string description, DateTime timeStamp, int rentalId)
        {
            throw new NotImplementedException();
        }

        public void RegisterScooter(DateTime registerDate, ScooterState state, string stationId)
        {
            throw new NotImplementedException();
        }

        public void RegisterStation(string address, double latitude, double longitude, string stationId)
        {
            if (dal.GetById<Station>(stationId) == null) {

                Station stat = new Station(address, stationId, longitude, latitude);
                dal.Insert<Station>(stat);
                dal.Commit();


            }
            throw new NotImplementedException();
        }

        public void RegisterUser(DateTime birthDate, string dni, string email, string name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
        {
            throw new NotImplementedException();
        }

        public void removeAllData()
        {
            throw new NotImplementedException();
        }

        public void RentScooter(string stationId)
        {
            throw new NotImplementedException();
        }

        public void ReturnScooter(string stationId)
        {
            if(dal.Exists<Station>(stationId))
            {
                ICollection<Rental> rentals = loggedMember.Rentals;
                Rental alquiler = rentals.Last<Rental>();

                Scooter sc = alquiler.scooter;

                Station st = dal.GetById<Station>(stationId);

                ICollection<TrackPoint> tps = alquiler.TrackPoints;


               

                alquiler.destination = st;
                alquiler.EndDate = DateTime.Now;

                int tiempo = (alquiler.EndDate.Value.Hour*60 + alquiler.EndDate.Value.Minute) - (alquiler.StartDate.Hour * 60 + alquiler.StartDate.Minute);
                double precio = this.fare*tiempo;
                int edad =  (((TimeSpan)(DateTime.Now-loggedMember.Birthdate)).Days)/360;



                if (edad > 16 && edad < 25)
                {
                    precio = precio * 0.9;
                }


                TrackPoint[] arrayTps = tps.ToArray<TrackPoint>();
                int i = 0;
                while (i < arrayTps.Length)
                {
                    if (arrayTps[i].Speed > this.maxSpeed)
                    {
                        precio = precio * 1.10;
                        break;
                    }
                }

                alquiler.Price = precio;


            } else
            {
                throw new ServiceException("");
            }
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
