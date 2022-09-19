using Dotnet_Angular.Domain;
using Dotnet_Angular.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;

namespace Dotnet_Angular.Database;

public interface IUserRepository : IRepository<User>
{
    Task<UserModel> GetModelAsync(long id);

    Task<Grid<UserModel>> GridAsync(GridParameters parameters);

    Task<IEnumerable<UserModel>> ListModelAsync();

    Task UpdateStatusAsync(User user);
}
