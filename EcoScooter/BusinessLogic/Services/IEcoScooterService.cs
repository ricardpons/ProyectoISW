using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoScooter.Services
{
    interface IEcoScooterService
    {
        void registrarse(String name, String dni, DateTime birthDate, int telephon, String email, int Cvv, DateTime ExpirationDate, int Number, String Login, String Password);
        void iniciarSesionUsuario(String Login, String password);
        void iniciarSesionEmpleado(String Login, String password);
        void registroEstacion(String Adress, double Latitude, double Longitude, int Id);
        void registroPatinete(DateTime RegisterDate , ScooterState State);
        void alquilarPatinete(Station origin);
        void devolverPatinete(Station destination);
        void registrarIncidente(String desciption, DateTime TimeStamp);
        void obtenerRecorridos(DateTime startTime, DateTime endTime);

    }
}
