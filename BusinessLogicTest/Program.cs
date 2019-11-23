using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoScooter.Entities;
using EcoScooter.Persistence;
using EcoScooter.Services;
using System.Data.Entity.Validation;

namespace BusinessLogicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IEcoScooterService service = new EcoScooterService(new EntityFrameworkDAL(new EcoScooterDbContext()));

                new Program(service);
            }
            catch (Exception e)
            {
                printError(e);
                Console.WriteLine("Press any key.");
                Console.ReadLine();
            }
        }

        static void printError(Exception e)
        {
                while (e != null)
                {
                    if (e is DbEntityValidationException)
                    {
                        DbEntityValidationException dbe = (DbEntityValidationException)e;

                        foreach (var eve in dbe.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                    ve.PropertyName,
                                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                    ve.ErrorMessage);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: " + e.Message);
                    }
                    e = e.InnerException;
                }
            }


        private IEcoScooterService service;

        Program(IEcoScooterService service)
        {
            this.service = service;

            service.removeAllData();

            // Adding EcoScooter
            addEcoScooter();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Adding Users
            addUsers();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Testing login
            testLogin();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // More login testing
            testLogin2();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Adding Stations
            addStations();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Adding Scooters
            addScooters();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Renting Scooters
            rentScooters();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Returning Scooters
            returnScooters();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // Get User Routes
            getUserRoutes();
            Console.WriteLine("FINISH - Press any key to continue...");
            Console.ReadKey();

        }

        void addEcoScooter()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING ECOSCOOTER...");

            try
            {
                // Administrator
                // public Employee(DateTime birthDate, String dni, String email, String name, int telephon, String iban, int pin, String position, Decimal salary )
                Employee e = new Employee(DateTime.Parse("19/10/2000"), "12341234A", "admin@ecoscooter.com", "Rodolfo Valentino", 96123123, "ES651234567890", 1234, "Administrator", 3000);
                
                EcoScooter.Entities.EcoScooter ecoscooter;
                // public EcoScooter(Double discountYounger, Double fare, Double maxSpeed, Employee firstEmpl)
                ecoscooter = new EcoScooter.Entities.EcoScooter(10, 0.015, 30, e);
                
                service.addEcoScooter(ecoscooter);
                Console.WriteLine(ecoScooterToString(service.getEcoScooter()));

                Console.WriteLine("   Employee list:");
                foreach (Employee emp in ecoscooter.Employees)
                    Console.WriteLine(employeeToString(emp));
            }
            catch (Exception e)
            {
                printError(e);
            }

        }

        String ecoScooterToString(EcoScooter.Entities.EcoScooter e)
        {
            return "   DiscountYounger: " + e.DiscountYounger + "  MaxSpeed: " + e.MaxSpeed + ", fare = " + e.Fare;
        }

        void addUsers()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING USERS...");

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/2001"), "11111111A", "user1@gmail.com", "First User", 606123123, 123, Convert.ToDateTime("01/01/2025"), "user1", 12345678, "user1");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/2010"), "22222222B", "user2@gmail.com", "Second User", 605321321, 321, Convert.ToDateTime("01/01/2025"), "user2", 12345679, "user2");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/2000"), "33333333B", "user3@gmail.com", "Third User", 604321321, 321, Convert.ToDateTime("01/01/2025"), "user1", 12345670, "user3");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/2001"), "44444444A", "user4@gmail.com", "Fourth User", 606456123, 133, Convert.ToDateTime("31/10/2019"), "user4", 15345678, "user4");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/1989"), "55555555A", "user5@gmail.com", "Fifth User", 608123888, 123, Convert.ToDateTime("01/01/2025"), "user5", 12435678, "user5");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/1989"), "66666666A", "user6@gmail.com", "Sixth User", 606666888, 623, Convert.ToDateTime("01/01/2024"), "user6", 12466676, "user6");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                // public User(DateTime birthDate, String dni, String email, String name, int telephon, int cvv, DateTime expirationDate, string login, int number, string password)
                User u1 = new User(Convert.ToDateTime("01/01/1988"), "77777777G", "user7@gmail.com", "Seventh User", 606677888, 627, Convert.ToDateTime("01/01/2023"), "user7", 17467676, "user7");
                service.registerUser(u1);
            }
            catch (Exception e)
            {
                printError(e);
            }

            foreach (User u in service.getAllUsers())
                    Console.WriteLine(userToString(u));
        }


        String userToString(User u)
        {
            return "   Name: " + u.Name + " dni: " + u.Dni + " email: " + u.Email + " login: " + u.Login + " password: " + u.Password;
        }


        String employeeToString(Employee e)
        {
            return "   Name: " + e.Name + " dni: " + e.Dni + " pin: " + e.Pin;
        }

        void testLogin()
        {
            User u;
            Console.WriteLine();
            Console.WriteLine("TESTING LOGIN...");

            try
            {
                u = service.login("user1", "user1");
                if (u != null)
                    Console.WriteLine("  Login " + u.Name);
                else
                    Console.WriteLine("  NOLOGIN");
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                u = service.login("user2", "user2");
                if (u != null)
                    Console.WriteLine("  Login " + u.Name);
                else
                    Console.WriteLine("  NOLOGIN");
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                u = service.login("user5", "user1");
                if (u != null)
                    Console.WriteLine("  Login " + u.Name);
                else
                    Console.WriteLine("  NOLOGIN");
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                Employee e = service.login("11111111A", 1234);
                if (e != null)
                    Console.WriteLine("  Login " + e.Name);
                else
                    Console.WriteLine("  NOLOGIN");
            }
            catch (Exception exc)
            {
                printError(exc);
            }
            service.logout();

            try
            {
                Employee e = service.login("12341234A", 1234);
                if (e != null)
                    Console.WriteLine("  Login " + e.Name);
                else
                    Console.WriteLine("  NOLOGIN");
            }
            catch (Exception exc)
            {
                printError(exc);
            }

        }


        void testLogin2()
        {
            Console.WriteLine();
            Console.WriteLine("TESTING MORE ABOUT LOGIN...");

            try
            {
                if (service.loggedAsUser())
                    Console.WriteLine("   User " + service.userLogged().Name + " logged in");
                else if (service.loggedAsEmployee())
                    Console.WriteLine("   Employee " + service.employeeLogged().Name + " logged in");
                else
                    Console.WriteLine("   Nobody logged in");

                service.logout();

                if (service.loggedAsUser())
                    Console.WriteLine("   User " + service.userLogged().Name + " logged in");
                else if (service.loggedAsEmployee())
                    Console.WriteLine("   Employee " + service.employeeLogged().Name + " logged in");
                else
                    Console.WriteLine("   Nobody logged in");

                service.login("user1", "user1");
                if (service.loggedAsUser())
                    Console.WriteLine("   User " + service.userLogged().Name + " logged in");
                else if (service.loggedAsEmployee())
                    Console.WriteLine("   Employee " + service.employeeLogged().Name + " logged in");
                else
                    Console.WriteLine("   Nobody logged in");
            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        void addStations()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING STATIONS...");

            try
            {
                // public Station(string address, string id, Double latitude, Double longitude)
                Station s = new Station("addres1", "st1", 1.01, 1.01);
                service.registerStation(s);
                s = new Station("addres2", "st2", 2.02, 2.02);
                service.registerStation(s);
                s = new Station("addres3", "st3", 3.03, 3.03);
                service.registerStation(s);
                s = new Station("addres4", "st4", 4.04, 4.04);
                service.registerStation(s);
                s = new Station("addres5", "st5", 5.05, 5.05);
                service.registerStation(s);
                s = new Station("addres6", "st1", 6.06, 6.06);
                service.registerStation(s);

            }
            catch (Exception e)
            {
                printError(e);
            }

            foreach (Station s in service.getAllStations())
                Console.WriteLine(stationToString(s));
        }

        String stationToString(Station s)
        {
            return "   Station.Id: " + s.Id + " address: " + s.Address + " latitude: " + s.Latitude; 
        }


        void addScooters()
        {
            Console.WriteLine();
            Console.WriteLine("ADDING SCOOTERS...");

            try
            {
                // public Scooter(DateTime registerDate, ScooterState state)
                Scooter sc = new Scooter(Convert.ToDateTime("01/10/2019"), ScooterState.available);
                service.registerScooter(sc);
                Station st = service.findStationById("st1");
                st.assignScooter(sc);
                service.saveChanges();

                sc = new Scooter(Convert.ToDateTime("01/10/2019"), ScooterState.available);
                service.registerScooter(sc);
                st.assignScooter(sc);
                service.saveChanges();

                sc = new Scooter(Convert.ToDateTime("01/10/2019"), ScooterState.available);
                service.registerScooter(sc);
                st.assignScooter(sc);
                service.saveChanges();

                sc = new Scooter(Convert.ToDateTime("01/10/2019"), ScooterState.inMaintenance);
                service.registerScooter(sc);
                st.assignScooter(sc);
                service.saveChanges();
            }
            catch (Exception e)
            {
                printError(e);
            }

            foreach (Scooter s in service.getAllScooters())
                Console.WriteLine(scooterToString(s));

        }

        String scooterToString(Scooter s)
        {
            string r = "   Scooter.Id: " + s.Id + " state: " + s.State;
            if(s.State == ScooterState.available)
                r = r + " station: " + s.Station.Id;
            if (s.State == ScooterState.inUse)
                r = r + " by: " + s.lastRental().User.Name;

            return r;
        }

        void rentScooters()
        {
            Console.WriteLine();
            Console.WriteLine("RENTING SCOOTERS...");

            try
            {
                service.login("user1", "user1");
                Station st = service.findStationById("st1");
                Scooter sc = st.chooseScooterToRent();
                User us = service.userLogged();
                // public Rental(DateTime startDate, Station originStation, Scooter scooter, User user)
                Rental rental = new Rental(DateTime.Now.AddMinutes(-800), st, sc, us);
                service.rentScooter(rental);
                service.logout();
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                service.login("user1", "user1");
                Station st = service.findStationById("st1");
                Scooter sc = st.chooseScooterToRent();
                User us = service.userLogged();
                // public Rental(DateTime startDate, Station originStation, Scooter scooter, User user)
                Rental rental = new Rental(DateTime.Now.AddMinutes(-800), st, sc, us);
                service.rentScooter(rental);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                service.login("user5", "user5");
                Station st = service.findStationById("st1");
                Scooter sc = st.chooseScooterToRent();
                User us = service.userLogged();
                // public Rental(DateTime startDate, Station originStation, Scooter scooter, User user)
                Rental rental = new Rental(DateTime.Now.AddMinutes(-400), st, sc, us);
                service.rentScooter(rental);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                service.login("user6", "user6");
                Station st = service.findStationById("st1");
                Scooter sc = st.chooseScooterToRent();
                User us = service.userLogged();
                // public Rental(DateTime startDate, Station originStation, Scooter scooter, User user)
                Rental rental = new Rental(DateTime.Now.AddMinutes(-200), st, sc, us);
                service.rentScooter(rental);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                service.login("user7", "user7");
                Station st = service.findStationById("st1");
                Scooter sc = st.chooseScooterToRent();
                User us = service.userLogged();
                // public Rental(DateTime startDate, Station originStation, Scooter scooter, User user)
                Rental rental = new Rental(DateTime.Now.AddMinutes(-200), st, sc, us);
                service.rentScooter(rental);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            foreach (Scooter s in service.getAllScooters())
                Console.WriteLine(scooterToString(s));

        }



        void returnScooters()
        {
            Console.WriteLine();
            Console.WriteLine("RETURN SCOOTERS...");

            try
            {
                service.login("user1", "user1");
                Station st = service.findStationById("st2");
                User us = service.userLogged();
                Rental r = us.lastRental();
                decimal price = service.returnScooter(r, st);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                service.login("user1", "user1");
                Station st = service.findStationById("st2");
                User us = service.userLogged();
                Rental r = us.lastRental();
                decimal price = service.returnScooter(r, st);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                service.login("user5", "user5");
                Station st = service.findStationById("st3");
                User us = service.userLogged();
                Rental r = us.lastRental();
                decimal price = service.returnScooter(r, st);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            try
            {
                service.login("user6", "user6");
                Station st = service.findStationById("st4");
                User us = service.userLogged();
                Rental r = us.lastRental();
                Incident i = new Incident("Crash with a mobile streetlamp", DateTime.Now);
                r.addIncident(i);
                decimal price = service.returnScooter(r, st);
            }
            catch (Exception e)
            {
                printError(e);
            }
            service.logout();

            foreach (Rental r in service.getAllRentals())
            {
                Console.WriteLine(rentalToString(r));
                if (r.Incident != null)
                    Console.WriteLine("      " + r.Incident.Description + " time: " + r.Incident.TimeStamp);
            }
        }

        String rentalToString(Rental r)
        {
            string s = "   Rental.Id: " + r.Id + " origin: " + r.OriginStation.Id;
            if (r.DestinationStation != null)
            {
                s = s + " destination: " + r.DestinationStation.Id + " price: " + r.Price;
            }
            return s;
        }

        void getUserRoutes()
        {
            Console.WriteLine();
            Console.WriteLine("GET USER ROUTES...");


            try
            {
                service.login("user1", "user1");
                Station st = service.findStationById("st2");
                Scooter sc = st.chooseScooterToRent();
                User us = service.userLogged();
                // public Rental(DateTime startDate, Station originStation, Scooter scooter, User user)
                Rental rental = new Rental(DateTime.Now.AddMinutes(-200), st, sc, us);
                service.rentScooter(rental);
                st = service.findStationById("st3");
                rental = us.lastRental();
                decimal price = service.returnScooter(rental, st);
                service.logout();
            }
            catch (Exception e)
            {
                printError(e);
            }

            try
            {
                service.login("user1", "user1");
                User us = service.userLogged();
                List<Rental> lR = service.getRentalsByDate(us, DateTime.Now.AddMinutes(-300), DateTime.Now);
                
                foreach (Rental r in lR)
                    Console.WriteLine(rentalToString(r));

            }
            catch (Exception e)
            {
                printError(e);
            }


        }



    }
}
