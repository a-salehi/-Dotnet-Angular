using Dotnet_Angular.Domain;
using Dotnet_Angular.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Angular.Database;

public sealed class UserRepository : EFRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) { }

    public Task<UserModel> GetModelAsync(long id)
    {
        return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.Model).SingleOrDefaultAsync()!;
    }

    public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
    {
        return Queryable.Select(UserExpression.Model).GridAsync(parameters);
    }

    public async Task<IEnumerable<UserModel>> ListModelAsync()
    {
        return await Queryable.Select(UserExpression.Model).ToListAsync();
    }

    public Task UpdateStatusAsync(User user)
    {
        return UpdatePartialAsync(new { user.Id, user.Status });
    }
}
