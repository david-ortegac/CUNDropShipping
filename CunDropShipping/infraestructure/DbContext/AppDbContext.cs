using CUNDropShipping.infraestructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CUNDropShipping.infraestructure.DbContext;

public class AppDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Products> Products { get; set; }
}