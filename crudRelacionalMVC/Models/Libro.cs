using System;
using System.Collections.Generic;

#nullable disable

namespace crudRelacionalMVC.Models
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdBibliotecaria { get; set; }

        public virtual Bibliotecarium IdBibliotecariaNavigation { get; set; }
    }
}
