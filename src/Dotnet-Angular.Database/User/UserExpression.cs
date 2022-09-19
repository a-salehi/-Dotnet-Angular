using Dotnet_Angular.Domain;
using Dotnet_Angular.Model;
using System.Linq.Expressions;

namespace Dotnet_Angular.Database;

public static class UserExpression
{
    public static Expression<Func<User, UserModel>> Model => user => new UserModel
    {
        Id = user.Id,
        FirstName = user.Name.FirstName,
        LastName = user.Name.LastName,
        Place = user.Place.Value,
        Email = user.Email.Value
    };

    public static Expression<Func<User, bool>> Id(long id)
    {
        return user => user.Id == id;
    }
}
