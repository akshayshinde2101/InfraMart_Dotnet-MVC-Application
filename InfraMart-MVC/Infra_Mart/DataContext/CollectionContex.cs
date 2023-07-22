namespace Infra_Mart.DataContext;
using Infra_Mart.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

public class CollectionContex : DbContext
{
   

    public CollectionContex(DbContextOptions options) : base(options)
    {

    }
    public DbSet<User> User { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Cart> Cart { get; set; }
  
}

