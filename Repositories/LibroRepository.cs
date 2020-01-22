using ClassLibrary1;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Status = Entities.Status;

namespace Repositories
{
    public class LibroRepository
    {
        public List<Libro> GetAllLibros()
        {
            List<Libro> lst;
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {
                lst = (from d in db.Libros
                       select new Libro
                       {
                           Id = d.ID,
                           Stock = d.Stock,
                           StockMax = d.StockMax,
                           Nombre = d.Libros1,
                           Precio = d.Precio,
                           Status = new Entities.Status
                           {
                               Id = d.Status.ID,
                               StatusName = d.Status.Status1
                           }

                       }).ToList();
            };
            return lst;
        }

        public Libro GetLibroById(int id)
        {
            Libros libroDeLaBase = new Libros();
            //Libro libroLLeno = new Libro(1, "nombreLoco"); //Como usar un constructor para crear un libro ya lleno
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {
                libroDeLaBase = db.Libros.Find(id);
                LlenarStatus(libroDeLaBase.Status);

            };

            Libro libro = LlenarModeloDeLibro(libroDeLaBase);
            return libro;
        }

        public List<Libro> GetLibrosByName(string name)
        {
            List<Libros> librosDeLaBase = new List<Libros>();
            //Libro libroLLeno = new Libro(1, "nombreLoco"); //Como usar un constructor para crear un libro ya lleno
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {
                librosDeLaBase = db.Libros.Where(l => l.Libros1.Contains(name)).Include(s => s.Status).ToList();
            };

            //Creamos nuestra lista que va a almacenar nuestros libros (entidad) llenos con el foreach
            List<Libro> librosPorNombre = new List<Libro>();

            foreach (Libros libroDeLaBase in librosDeLaBase)
            {
                //Tomamos cada libro y lo hacemos que llene la entidad y se guarde en la lista "librosPorNombre"
                var libroLleno = LlenarModeloDeLibro(libroDeLaBase);
                librosPorNombre.Add(libroLleno);
            }

            return librosPorNombre;
        }


        private Libro LlenarModeloDeLibro(Libros libroDeLaBase)
        {
            var libro = new Libro();

            libro.Id = libroDeLaBase.ID;
            libro.Nombre = libroDeLaBase.Libros1;
            libro.Precio = libroDeLaBase.Precio;
            libro.Status = LlenarStatus(libroDeLaBase.Status);
            libro.Stock = libroDeLaBase.Stock;
            libro.StockMax = libroDeLaBase.StockMax;

            return libro;
        }

        private Status LlenarStatus(ClassLibrary1.Status statusDeLaBase)
        {
            var status = new Status();

            status.Id = statusDeLaBase.ID;
            status.StatusName = statusDeLaBase.Status1;
            status.StatusEnum = (Status.StatusType)statusDeLaBase.ID;

            return status;
        }
        public Libro ModificarPrecio(int id, decimal nuevoPrecio)
        {

            var libro = new Libro();
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {
                var oLibro = db.Libros.Find(id);
                oLibro.Precio = nuevoPrecio;
                db.SaveChanges();
            }

            return libro;
        }

        public Libro EditarLibroCompleto(Libro libro)
        {
            //Libro Libro = new Libro();
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {
                var llenarLibro = db.Libros.Find(libro.Id);

                llenarLibro.Libros1 = libro.Nombre;
                llenarLibro.ID = libro.Id;
                llenarLibro.Status = db.Status.Find((int)libro.Status.StatusEnum);
                llenarLibro.Stock = libro.Stock;
                llenarLibro.StockMax = libro.StockMax;
                llenarLibro.Precio = libro.Precio;

                db.SaveChanges();
            }
            return (libro);
        }
        public Libro EditarStockParaAlquilar(int id)
        {
            var libroAAlquilar = GetLibroById(id);
            if (libroAAlquilar.StockMax > 0)
            {
                libroAAlquilar.Stock = libroAAlquilar.Stock - 1;
                EditarLibroCompleto(libroAAlquilar);
            }

            return (libroAAlquilar);
        }




        public void CrearLibro(Libro libro) // REVISAR LIBRO Y LIBROS PARA VER Q TIENE Q ENTRAR Y Q SALIR BIEN 
        {
            var libroNuevo = new Libros();
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {
                //var statusName = Enum.GetName(typeof(Status.StatusType), libro.Status.StatusId);
                var statusId = (int)libro.Status.StatusEnum;
                var status = db.Status.Find(statusId);

                libroNuevo.Libros1 = libro.Nombre;
                libroNuevo.Status = status;
                libroNuevo.Stock = libro.Stock;
                libroNuevo.Precio = libro.Precio;
                db.Libros.Add(libroNuevo);
                db.SaveChanges();
            }

            //return (libroNuevo);
        }
        public void Eliminar(int Id)
        {
            Libro LibroAEliminar = new Libro();
            using (LibreriaOnlineEntities db = new LibreriaOnlineEntities())
            {

                Libros LibroDLaBase = db.Libros.Find(Id);
                db.Libros.Remove(LibroDLaBase);
                LibroAEliminar.Nombre = LibroDLaBase.Libros1;
                // se tiene que borrar tanto de la base como de las entities sino sigue el dato en un lado y en el otro no 
                db.SaveChanges();
            }
        }





        //public int ObtenerMenorNumeroCuyaSumaDeDigitosSeaIgualAlNumeroDado(int N)
        //{
        //    if (N >= 10)
        //    {
        //        for (int i = 10; i < 999999; i++)
        //        {
        //            var sum = sumDigits(i);

        //            if (sum == N)
        //            {
        //                return i;
        //            }
        //        }
        //    }

        //    return N;
        //}

        //public int sumDigits(int i)
        //{
        //    var sum = 0;
        //    while (i != 0)
        //    {
        //        sum += i % 10;
        //        i /= 10;
        //    }

        //    return sum;

        //}
    }
}
