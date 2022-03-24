using System;
using System.Collections.Generic;

#nullable disable

namespace crudRelacionalMVC.Models
{
    public partial class Bibliotecarium
    {
        public Bibliotecarium()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdBibliotecaria { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdBiblioteca { get; set; }

        public virtual Biblioteca IdBibliotecaNavigation { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
