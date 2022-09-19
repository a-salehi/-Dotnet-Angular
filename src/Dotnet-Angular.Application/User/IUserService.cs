using Dotnet_Angular.Model;
using DotNetCore.Objects;
using DotNetCore.Results;

namespace Dotnet_Angular.Application;

public interface IUserService
{
    Task<IResult<long>> AddAsync(UserModel model);

    Task<IResult> DeleteAsync(long id);

    Task<UserModel> GetAsync(long id);

    Task<Grid<UserModel>> GridAsync(GridParameters parameters);

    Task<IResult> InactivateAsync(long id);

    Task<IEnumerable<UserModel>> ListAsync();

    Task<IResult> UpdateAsync(UserModel model);
}
