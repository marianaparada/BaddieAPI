using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaddieAPI.Models;

[Table("Helicopteros", Schema = "dbo")]
public class Helicoptero
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Modelo { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Fabricante { get; set; } = string.Empty;

    public int? CapacidadPasajeros { get; set; }
    public int? Anio { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal? PesoMaxKg { get; set; }

    public bool Activo { get; set; } = true;
}