using Microsoft.EntityFrameworkCore;
using BaddieAPI.Models;

namespace BaddieAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Micro> Micro { get; set; }
    public DbSet<Helicoptero> Helicoptero { get; set; }
    public DbSet<Avion> Aviones { get; set; }
    public DbSet<Moto> Motos { get; set; }
    
    public DbSet<Barco> Barcos { get; set; }

}