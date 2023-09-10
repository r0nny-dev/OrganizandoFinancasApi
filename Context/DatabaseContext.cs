using Microsoft.EntityFrameworkCore;
using OrganizingFinances.Entities;

namespace OrganizingFinances.Context;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
                            
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

    DbSet<RegistroDivida> registroDividas { get; set; }
}
