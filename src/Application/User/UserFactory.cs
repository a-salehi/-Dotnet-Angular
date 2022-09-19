using Dotnet_Angular.Domain;
using Dotnet_Angular.Model;

namespace Dotnet_Angular.Application;

public sealed class UserFactory : IUserFactory
{
    public User Create(UserModel model)
    {
        return new User
        (
            new Name(model.FirstName, model.LastName),
            new Email(model.Email),
            new Place(model.Place)
        );
    }
}
