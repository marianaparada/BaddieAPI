using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaddieAPI.Models
{
    public class Moto
    {
        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string Marca { get; set; } = string.Empty;

        [Required, MaxLength(80)]
        public string Modelo { get; set; } = string.Empty;

        [Range(1950, 2100)]
        public int Anio { get; set; }

        [Range(50, 4000)]
        public int CilindradaCc { get; set; }

        [MaxLength(30)]
        public string Tipo { get; set; } = "naked";

        [Column(TypeName = "decimal(12,2)")]
        public decimal Precio { get; set; }

        public bool Disponible { get; set; } = true;

        public DateTime FechaIngreso { get; set; } = DateTime.UtcNow;
    }
}