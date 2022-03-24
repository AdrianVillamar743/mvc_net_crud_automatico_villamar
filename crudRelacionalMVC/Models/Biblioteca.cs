using System;
using System.Collections.Generic;

#nullable disable

namespace crudRelacionalMVC.Models
{
    public partial class Biblioteca
    {
        public Biblioteca()
        {
            Bibliotecaria = new HashSet<Bibliotecarium>();
        }

        public int IdBiblioteca { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Bibliotecarium> Bibliotecaria { get; set; }
    }
}
