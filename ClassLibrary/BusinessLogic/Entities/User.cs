using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Entities
{
    public partial class User : Person
    {
        public User() : base()
        {
            Rentals = new List<Rental>();
        }
        public User(DateTime birthDate, String dni, String email, String
       name, int telephon, int Cvv, DateTime ExpirationDate, String Login, int Number, String Password) : base(birthDate, dni, email, name, telephon)
        {
            this.Cvv = Cvv;
            this.ExpirationDate = ExpirationDate;
            this.Login = Login;
            this.Number = Number;
            this.Password = Password;

            Rentals = new List<Rental>();
        }
    }
}
