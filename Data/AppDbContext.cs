using Microsoft.EntityFrameworkCore;
using BaddieAPI.Models;

namespace BaddieAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Micro> Micro { get; set; }
    public DbSet<Helicoptero> Helicoptero => Set<Helicoptero>();
}