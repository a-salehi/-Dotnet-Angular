using Microsoft.EntityFrameworkCore;

namespace Dotnet_Angular.Database;

public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly).Seed();
    }
}
