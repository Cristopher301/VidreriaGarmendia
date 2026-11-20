
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidreriaGarmendia.Models;

/// <summary>
/// Entidad que representa la tabla dbo.Contactos de la base de datos
/// bdvidreria (servidor adminvidreria) en Azure SQL.
/// </summary>
[Table("Contactos")]
public class Contacto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    [StringLength(150)]
    public string Correo { get; set; } = string.Empty;

    [StringLength(30)]
    public string? Telefono { get; set; }

    [Required(ErrorMessage = "El mensaje es obligatorio.")]
    public string Mensaje { get; set; } = string.Empty;

    // La asigna el servidor al guardar; el cliente no necesita enviarla.
    public DateTime FechaRegistro { get; set; }
}
