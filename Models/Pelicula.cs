using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Filmera.Models;

public partial class Pelicula
{
    // ID
    [Required]
    public string IdPelicula { get; set; } = null!;

    // Titulo
    [Required]
    public string? Titulo { get; set; }

    // Sinopsis / Trama
    [Required]
    public string? Sinopsis { get; set; }

    // Director
    [Required]
    public string? Director { get; set; }

    // Genero
    [Required]
    public string? Genero { get; set; }

    // Duracion
    [Required]
    public int? Duracion { get; set; }

    // Calificacion
    [Required]
    public int? Calificacion { get; set; }

    // Año de lanzamiento
    [Required]
    public int? Lanzamiento { get; set; }

    // Público objetivo
    [Required]
    public string? Publico { get; set; }
}
