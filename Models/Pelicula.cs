using System;
using System.Collections.Generic;


namespace Filmera.Models;

public partial class Pelicula
{
    public string IdPelicula { get; set; } = null!;

    public string? Titulo { get; set; }

    public string? Sinopsis { get; set; }

    public string? Director { get; set; }

    public string? Genero { get; set; }

    public int? Duracion { get; set; }

    public int? Calificacion { get; set; }

    public int? Lanzamiento { get; set; }

    public string? Publico { get; set; }
}
