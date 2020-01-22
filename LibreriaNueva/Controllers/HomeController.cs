using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibreriaNueva.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Administracion() //administrador
        {
            //vemos como cambia en git
            var repository = new LibroRepository();
            List<Libro> listado = repository.GetAllLibros();

            return View(listado);
        }


        public ActionResult LibrosGrid(string name)
        {
            if (name != null)
            {
                var libros = GetLibrosByName(name);
                return View(libros);
            }

            return View();

        }

        public ActionResult GetLibroById(int id) // Obtenet libro por Id
        {
            var repository = new LibroRepository();
            Libro libro = repository.GetLibroById(id);

            return Json(libro, JsonRequestBehavior.AllowGet);
        }

        public List<Libro> GetLibrosByName(string name) // Obtenet libro por Id
        {
            var repository = new LibroRepository();
            List<Libro> libros = repository.GetLibrosByName(name);

            return libros;
        }

        //Aca hacer metodo getLibroByName muy parecido al de arriba pero con un string q busque por nombre

        public ActionResult ModificarPrecio(int id, decimal nuevoPrecio) // Obtenet libro por Nombre
        {
            var repository = new LibroRepository();
            Libro libro = repository.ModificarPrecio(id, nuevoPrecio);

            return Json(libro, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Editar(int Id)
        {
            var repository = new LibroRepository();
            var libro = repository.GetLibroById(Id);

            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Libro libro)
        {
            var repository = new LibroRepository();
            libro = repository.EditarLibroCompleto(libro);

            return Redirect("~/Home/Administracion");
        }

        public ActionResult Eliminar(int Id)
        {
            var repository = new LibroRepository();
            repository.Eliminar(Id);

            return Redirect("~/Home/Administracion");

        }

        // Aca hay que agregar ALQUILAR Y DEVOLVER LIBRO 
        // hay que tener una variable para el stock total del libro 
        // y habria que ver como mostrarlo en un registro en otra vista (mas complejo)
       
        public ActionResult Alquilar(int id)
        {
            var repository = new LibroRepository();
            repository.EditarStockParaAlquilar(id);
            return Redirect("~/Home/Administracion");
        }







        public ActionResult NuevoLibro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoLibro(Libro libro)
        {
            var repository = new LibroRepository();
            repository.CrearLibro(libro);

            return Redirect("~/Home/Administracion");
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

        //public int solution4(int[] A)
        //{
        //    List<int> newArray = new List<int>();

        //    foreach (int number in A)
        //    {
        //        if (number == -1)
        //        {
        //            if (Array.IndexOf(A, -1) != (A.Length - 1))
        //            {
        //                int lastNumber = A[A.Length - 1];
        //                newArray.Add(lastNumber);
        //            }

        //            newArray.Add(number);
        //            break;
        //        }
        //        else
        //        {
        //            newArray.Add(number);
        //        }

        //    }

        //    return newArray.Count();
        //}

        //public int solution(int[] A, int[] B)
        //{
        //    int n = A.Length;
        //    int m = B.Length;

        //    Array.Sort(A);
        //    Array.Sort(B);

        //    int i = 0;
        //    for (int k = 0; k < n; k++)
        //    {
        //        if (i < m - 1 && B[i] < A[k])
        //            i = Array.IndexOf(B, A[k]) == -1 ? i + 1 : Array.IndexOf(B, A[k]);
        //        if (A[k] == B[i])
        //            return A[k];
        //    }
        //    return -1;
        //}

        //public int solution(int[] A)
        //{
        //    int[] newArray = new int[A.Length];

        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        if (A[i] == -1)
        //        {
        //            int lastNumber = A[A.Length - 1];
        //            newArray[i] = lastNumber;
        //            newArray[i + 1] = A[i];
        //            i = A.Length;
        //        }
        //        else
        //        {
        //            newArray[i] = A[i];
        //        }
        //    }
        //    return newArray.Length;
        //}







    }
}
