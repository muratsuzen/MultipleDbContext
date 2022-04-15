using Microsoft.EntityFrameworkCore;

namespace MultipleDbContext.Data;

public class DbOneContext : BaseContext
{
    public DbOneContext(DbContextOptions<DbOneContext> options) : base(options)
    {

    }
}