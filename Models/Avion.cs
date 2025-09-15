namespace BaddieAPI.Models;

public class Avion
{
    public int Id { get; set; }
    public string Matricula { get; set; } = string.Empty; // CP-1234
    public string Marca { get; set; } = string.Empty;     // Boeing
    public string Modelo { get; set; } = string.Empty;    // 737-800
    public int Anio { get; set; }                         // 2015
    public int Capacidad { get; set; }                    // pasajeros
}