using Microsoft.EntityFrameworkCore;

namespace MultipleDbContext.Data;

public class DbTwoContext : BaseContext
{
    public DbTwoContext(DbContextOptions<DbTwoContext> options) : base(options)
    {
    }
}