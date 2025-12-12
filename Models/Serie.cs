using System;
using System.Collections.Generic;

namespace Filmera.Models;

public partial class Serie
{
    public string IdSerie { get; set; } = null!;

    public string? Titulo { get; set; }

    public string? Sinopsis { get; set; }

    public string? Genero { get; set; }

    public int? Temporadas { get; set; }

    public int? Episodios { get; set; }

    public int? Calificacion { get; set; }

    public int? Lanzamiento { get; set; }

    public string? Publico { get; set; }
}
