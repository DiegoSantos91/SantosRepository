using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaNueva.Models
{
    public class LibroViewModel
    {
        public int id { get; set; }
        public int? IdStatus { get; set; }

        public int? Stock { get; set; }
        public int? StockMax { get; set; }
        public decimal? Precio { get; set; }
        public string Libros1 { get; set; }
        public int? IdComprador { get; set; }
    }
}