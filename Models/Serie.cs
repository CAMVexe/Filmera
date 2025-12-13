using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmera.Models;

public partial class Serie
{
    // Código de identificación
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar el código de identificación")]
    [RegularExpression(@"^Ser-\d+$", ErrorMessage = "El código de identificación de la serie debe tener el formato 'Ser-' seguido del número de identificación")]
    public string IdSerie { get; set; } = null!;

    // Título
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar el título")]
    [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
    [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    // Sinopsis
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar la sinopsis")]
    [MinLength(10, ErrorMessage = "La sinopsis tiene que dar al menos una ligera idea de la serie, utilizar al menos 10 caracteres")]
    [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Sinopsis { get; set; } = string.Empty;

    // Genero
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar el género")]
    public string Genero { get; set; } = string.Empty;

    // Temporadas
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar la cantidad de temporadas")]
    [Range(1, 70, ErrorMessage = "La cantidad de temporadas no puede ser negativa, y el número más alto posible hasta el momento es 70, corrobore y si es necesario informe")]
    public int Temporadas { get; set; }

    // Episodios
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar la cantidad de episodios")]
    [Range(1, 8000, ErrorMessage = "La cantidad de episodios no puede ser negativo, y el número más alto posible hasta el momento es 8000, corrobore y si es necesario informe")]
    public int Episodios { get; set; }

    // Calificacion
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar la clasificación")]
    [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100")]
    public int Calificacion { get; set; }

    // Año de lanzamiento
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar el año de lanzamiento")]
    [Range(1900, 2100, ErrorMessage = "El año no puede ser mayor al año actual")]
    public int Lanzamiento { get; set; }

    // Publico objetivo
    [Required(ErrorMessage = "Para poder agregar la serie es necesario ingresar el público objetivo")]
    public string Publico { get; set; } = string.Empty;
}
