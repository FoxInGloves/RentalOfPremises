using Microsoft.EntityFrameworkCore;
using RentalOfPremises.Models.Data;

namespace RentalOfPremises.Repository;

public sealed class DataBaseContext : DbContext
{
    public DbSet<RentalData> PremisesTable { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "server=127.0.0.1;user=root;password=123456789;database=rentaldb;CharSet=utf8;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}