using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmera.Models;

public partial class Pelicula
{
    // Código de identificación
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar el código de identificación")]
    [RegularExpression(@"^Mov-\d+$", ErrorMessage = "El código de identificación de la película debe tener el formato 'Mov-' seguido del número de identificación")]
    public string IdPelicula { get; set; } = null!;

    // Título
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar el título")]
    [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    // Sinopsis
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar la sinopsis")]
    [MinLength(10, ErrorMessage = "La sinopsis tiene que dar al menos una ligera idea de la película, utilizar al menos 10 caracteres")]
    public string Sinopsis { get; set; } = string.Empty;

    // Director
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar el director")]
    [MinLength(5, ErrorMessage = "Nombre del director muy pequeño, si no lo ha hecho ingrese también el apellido")]
    public string Director { get; set; } = string.Empty;

    // Genero
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar el género")]
    public string Genero { get; set; } = string.Empty;

    // Duracion (minutos)
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar la duración")]
    [Range(1, 500, ErrorMessage = "La duración de la película es por lo general entre 1 y 500 minutos, por favor corrobore o presente un informe al respecto")]
    public int Duracion { get; set; }

    // Calificacion
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar la clasificación")]
    [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100")]
    public int Calificacion { get; set; }

    // Año de lanzamiento
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar el año de lanzamiento")]
    [Range(1900, 2100, ErrorMessage = "El año no puede ser mayor al año actual")]
    public int Lanzamiento { get; set; } = DateTime.Now.Year;

    // Publico objetivo
    [Required(ErrorMessage = "Para poder agregar la película es necesario ingresar el público objetivo")]
    public string Publico { get; set; } = string.Empty;
}
