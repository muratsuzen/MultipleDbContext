using Microsoft.EntityFrameworkCore;
using MultipleDbContext.Models;

namespace MultipleDbContext.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
}