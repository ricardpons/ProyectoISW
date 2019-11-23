using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoScooter.Services;


namespace EcoScooter.Services
{
    class EcoScooterService : IEcoSooterService
    {

        private EntityFrameworkDAL dal;
        private EcoScooter ecoScooter;
        private User loggedMember;

        public EcoScooterService (EntityFrameworkDAL entityFrameworkDAL)
        {
            this.dal = entityFrameworkDAL;
            if(this.dal.GetAll<EcoScooter>().Count > 0)
            {
                this.ecoScooter = this.dal.GetAll<EcoScooter>().First();
            } else
            {
                this.ecoScooter = null;
            }
            this.loggedMember = null;
        }

        public void saveChanges()
        {
            dal.Commit();
        }

        public void removeAllData()
        {
            dal.removeAllData();
        }

    }
}
