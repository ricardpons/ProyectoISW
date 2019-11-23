using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Persistence
{
    public partial class Incident
    {
        public string Description
        {
            get;
            set;

        }

        public int ID
        {
            get;
            set;


        }

        public DateTime TimeStamp
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
