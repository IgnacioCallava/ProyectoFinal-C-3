using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion {  get; set; }

        // Método para sobreescribir el metodo ToString y que cuando llamemos al ToString nos devuelva la descripción.
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
