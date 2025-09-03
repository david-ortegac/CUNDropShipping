using Microsoft.EntityFrameworkCore;

namespace CUNDropShipping.infraestructure.conection;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}