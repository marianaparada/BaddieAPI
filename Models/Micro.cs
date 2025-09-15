using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaddieAPI.Models;

public class Micro
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Line { get; set; } = null!;            // p.ej. "17/18"

    [Required, MaxLength(10)]
    public string Plate { get; set; } = null!;           // placa

    [MaxLength(100)]
    public string DriverName { get; set; } = null!;      // chofer

    [MaxLength(100)]
    public string Company { get; set; } = null!;         // cooperativa/empresa

    [MaxLength(200)]
    public string Route { get; set; } = null!;           // descripción breve

    [Column(TypeName = "decimal(10,2)")]
    public decimal Fare { get; set; }                    // tarifa

    public int Seats { get; set; }                       // capacidad

    public bool InService { get; set; } = true;          // en servicio
}