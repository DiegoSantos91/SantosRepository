using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Libro : BaseEntity
    {
        public string Nombre { get; set; }
        public Status Status { get; set; }
        public int? Stock { get; set; }
        public int? StockMax { get; set; }
        public decimal? Precio { get; set; }

        public Libro()//constructor vacio (Si creo otro constructor, este tiene que estar!!, sino no hace falta)
        {
            
        }

        public Libro(int id, string nombre)//constructor
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
