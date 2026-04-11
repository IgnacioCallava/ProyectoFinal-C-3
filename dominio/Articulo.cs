using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //Necesario para el DisplayName

namespace dominio
{
    public class Articulo
    {
        // - Id - Código - Nombre - Descripción - Marca - Categoria - Imagen - Precio
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DisplayName("Descripción")]  //Nombre que se muestra en la columna cuando mostramos los datos
        public Marca Marca { get; set; }

        public Categoria Categoria { get; set; }
        [DisplayName("Categoría")]
        public string UrlImagen { get; set; }
        [DisplayName("Imagen")]

        public decimal Precio { get; set; }
        
    }
}
