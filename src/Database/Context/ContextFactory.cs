using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dotnet_Angular.Database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "Data Source=localhost;Initial Catalog=DBs;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=123456;Trust Server Certificate=True";

        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
    }
}
