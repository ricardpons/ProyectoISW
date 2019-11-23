using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Persistence
{
    public partial class User : Person
    {
        public int Cvv
        {
            get;
            set;
        }
        public DateTime ExpirationDate
        {
            get;
            set;
        }
        public String Login
        {
            get;
            set;
        }
        public int Number
        {
            get;
            set;
        }
        public String Password
        {
            get;
            set;
        }

        /*Relaciones*/

        public virtual ICollection<Rental> Rentals
        {
            get;
            set;
        }

    }
}
