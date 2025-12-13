using Microsoft.AspNetCore.Mvc;
using Filmera.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Filmera.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly FilmeraContext _context;
        public PeliculasController(FilmeraContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Peliculas = _context.Peliculas.ToList();
            return View(Peliculas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pelicula pelicula)
        {
            
            if (!ModelState.IsValid)
            {
                return View(pelicula);
            }

            // Comprobar existencia de la PK
            bool duplicate = _context.Peliculas.Any(p => p.IdPelicula == pelicula.IdPelicula);
            if (duplicate)
            {
                // Añadir error de validación y retornar la vista para que el usuario corrija
                ModelState.AddModelError(nameof(Pelicula.IdPelicula), "El código de identificación de película ya existe, por favor verifique.");
                return View(pelicula);
            }

            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();

            TempData["Mensaje"] = $"Película '{pelicula.Titulo}' registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult BuscarMov(string titulo)
        {
            var resultado = _context.Peliculas.Where(p => p.Titulo.Contains(titulo)).ToList();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                TempData["Mensaje"] = "Mostrando todas las películas, si desea buscar una película en específico, ingrese el titulo";
                return RedirectToAction(nameof(Index));
            }

            if (resultado.Count == 0)
            {
                TempData["Mensaje"] = $"No se encontraron películas con el titulo '{titulo}'.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", resultado);
        }

        [HttpPost]
        public IActionResult FiltroGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero))
            {
                TempData["Mensaje"] = "Mostrando todas las películas, si desea filtrar por género, seleccione una opción.";
                return RedirectToAction(nameof(Index));
            }

            var resultado = _context.Peliculas.Where(p => p.Genero == genero).ToList();
            if (!resultado.Any())
            {
                TempData["Mensaje"] = $"No se encontraron películas del género '{genero}'.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", resultado);
        }

        [HttpPost]
        public IActionResult FiltroClasificacion(string publico)
        {
            if (string.IsNullOrWhiteSpace(publico))
            {
                TempData["Mensaje"] = "Mostrando todas las películas. Si desea filtrar por público, seleccione una opción.";
                return RedirectToAction(nameof(Index));
            }

            var resultado = _context.Peliculas.Where(p => p.Publico == publico).ToList();
            if (!resultado.Any())
            {
                TempData["Mensaje"] = $"No se encontraron películas para el público '{publico}'.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", resultado);
        }

        // GET: mostrar el formulario de edición

        public IActionResult Edit(string IdPelicula)
        {
            var current = _context.Peliculas.Find(IdPelicula);
            if (current == null)
            {
                TempData["Mensaje"] = $"No se encontró la película con el código identificador {IdPelicula}.";
                return RedirectToAction(nameof(Index));
            }

            return View(current);
        }

        // POST: guardar los cambios enviados desde la vista Edit
        [HttpPost]
        public IActionResult Edit(Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return View(pelicula);
            }

            var existing = _context.Peliculas.Find(pelicula.IdPelicula);
            if (existing == null)
            {
                TempData["Mensaje"] = $"No se encontró la película con el código identificador {pelicula.IdPelicula}.";
                return RedirectToAction(nameof(Index));
            }

            _context.Entry(existing).CurrentValues.SetValues(pelicula); // Entry(r) = obtiene registro r | CurrentValues = valores actuales del registro | SetValues(m) = asigna los valores del peliculao m
            _context.SaveChanges();

            TempData["Mensaje"] = $"Película '{pelicula.Titulo}' actualizado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string IdPelicula)
        {
            var producto = _context.Peliculas.Find(IdPelicula);

            if (producto == null)
            {
                TempData["Mensaje"] = $"No se encontró la película con el código identificador {IdPelicula}.";
                return RedirectToAction(nameof(Index));
            }

            _context.Peliculas.Remove(producto);
            _context.SaveChanges();

            TempData["Mensaje"] = $"La película {producto.Titulo} se eliminó correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // Funciones Linq

        public IActionResult OrderTitulo()
        {
            var ordered = _context.Peliculas.OrderBy(p => p.Titulo).ToList();
            return View("Index", ordered);
        }

        public IActionResult OrderFecha()
        {
            var ordered = _context.Peliculas.OrderByDescending(p => p.Lanzamiento).ToList();
            return View("Index", ordered);
        }

        public IActionResult OrderRating()
        {
            var ordered = _context.Peliculas.OrderByDescending(p => p.Calificacion).ToList();
            return View("Index", ordered);
        }


    }
}