using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    // Enum para tener distintos tipos de usuarios y dependiendo el tipo, los accesos que van a tener
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        // Propiedades de la clase Usuario
        public int Id { get; set; }
        // Email
        private string email;
        public string Email
        {
            get { return email; } //Si se pide el email se retorna el email
            set // Si se quiere setear un email, se checkea que lo que se envía no esté vacio y si no esta vacio se guarda.
            {
                if (value != "")
                {
                    email = value;
                }
                else
                {
                    throw new Exception("email vacío en el dominio...");
                }
            }
        }

        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ImagenPerfil { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
