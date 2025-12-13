using Microsoft.AspNetCore.Mvc;
using Filmera.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Filmera.Controllers
{
    public class SeriesController : Controller
    {
        private readonly FilmeraContext _context;
        public SeriesController(FilmeraContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Series = _context.Series.ToList();
            return View(Series);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Serie serie)
        {

            if (!ModelState.IsValid)
            {
                return View(serie);
            }

            // Comprobar existencia de la PK
            bool duplicate = _context.Series.Any(p => p.IdSerie == serie.IdSerie);
            if (duplicate)
            {
                // Añadir error de validación y retornar la vista para que el usuario corrija
                ModelState.AddModelError(nameof(Serie.IdSerie), "El código de identificación de la serie ya existe, por favor verifique.");
                return View(serie);
            }

            _context.Series.Add(serie);
            _context.SaveChanges();

            TempData["Mensaje"] = $"Serie '{serie.Titulo}' registrada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // Buscar serie por título
        [HttpPost]
        public IActionResult BuscarSer(string titulo)
        {
            var resultado = _context.Series.Where(p => p.Titulo.Contains(titulo)).ToList();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                TempData["Mensaje"] = "Mostrando todas las series, si desea buscar una serie en específico, ingrese el titulo";
                return RedirectToAction(nameof(Index));
            }

            if (resultado.Count == 0)
            {
                TempData["Mensaje"] = $"No se encontraron series con el titulo '{titulo}'.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", resultado);
        }

        // GET: mostrar el formulario de edición

        public IActionResult Edit(string IdSerie)
        {
            var current = _context.Series.Find(IdSerie);
            if (current == null)
            {
                TempData["Mensaje"] = $"No se encontró la serie con el código identificador {IdSerie}.";
                return RedirectToAction(nameof(Index));
            }

            return View(current);
        }

        // POST: guardar los cambios enviados desde la vista Edit
        [HttpPost]
        public IActionResult Edit(Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return View(serie);
            }

            var existing = _context.Series.Find(serie.IdSerie);
            if (existing == null)
            {
                TempData["Mensaje"] = $"No se encontró la serie con el código identificador {serie.IdSerie}.";
                return RedirectToAction(nameof(Index));
            }

            _context.Entry(existing).CurrentValues.SetValues(serie); // Entry(r) = obtiene registro r | CurrentValues = valores actuales del registro | SetValues(m) = asigna los valores del modelo m
            _context.SaveChanges();

            TempData["Mensaje"] = $"Serie '{serie.Titulo}' actualizada correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // Eliminar serie
        public IActionResult Delete(string IdSerie)
        {
            var serie = _context.Series.Find(IdSerie);

            if (serie == null)
            {
                TempData["Mensaje"] = $"No se encontró la serie con el código identificador {IdSerie}.";
                return RedirectToAction(nameof(Index));
            }

            _context.Series.Remove(serie);
            _context.SaveChanges();

            TempData["Mensaje"] = $"La serie {serie.Titulo} se eliminó correctamente.";
            return RedirectToAction(nameof(Index));


        }

        // Funciones (consultas) Linq

        [HttpPost]
        public IActionResult FiltroGenero(string genero)
        {
            if (string.IsNullOrWhiteSpace(genero))
            {
                TempData["Mensaje"] = "Mostrando todas las series, si desea filtrar por género, seleccione una opción.";
                return RedirectToAction(nameof(Index));
            }

            var resultado = _context.Series.Where(p => p.Genero == genero).ToList();
            if (!resultado.Any())
            {
                TempData["Mensaje"] = $"No se encontraron series del género '{genero}'.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", resultado);
        }

        [HttpPost]
        public IActionResult FiltroClasificacion(string publico)
        {
            if (string.IsNullOrWhiteSpace(publico))
            {
                TempData["Mensaje"] = "Mostrando todas las series, si desea filtrar por público, seleccione una opción.";
                return RedirectToAction(nameof(Index));
            }

            var resultado = _context.Series.Where(p => p.Publico == publico).ToList();
            if (!resultado.Any())
            {
                TempData["Mensaje"] = $"No se encontraron series para el público '{publico}'.";
                return RedirectToAction(nameof(Index));
            }

            return View("Index", resultado);
        }

        public IActionResult OrderTitulo()
        {
            var ordered = _context.Series.OrderBy(p => p.Titulo).ToList();
            return View("Index", ordered);
        }

        public IActionResult OrderFecha()
        {
            var ordered = _context.Series.OrderByDescending(p => p.Lanzamiento).ToList();
            return View("Index", ordered);
        }

        public IActionResult OrderRating()
        {
            var ordered = _context.Series.OrderByDescending(p => p.Calificacion).ToList();
            return View("Index", ordered);
        }
    }
}
