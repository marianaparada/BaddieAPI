using System;
using System.ComponentModel.DataAnnotations;

namespace BaddieAPI.Models
{
    public class Barco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tipo { get; set; }  // Ej: Yate, Velero, Crucero

        [Required]
        [MaxLength(50)]
        public string NumeroRegistro { get; set; } // Registro único del barco

        public double Eslora { get; set; } // Longitud del barco en metros

        public int CapacidadPasajeros { get; set; }

        public bool EnOperacion { get; set; }

        public DateTime FechaConstruccion { get; set; }
    }
}