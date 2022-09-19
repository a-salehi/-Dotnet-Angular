using Dotnet_Angular.Domain;
using Dotnet_Angular.Model;

namespace Dotnet_Angular.Application;

public interface IUserFactory
{
    User Create(UserModel model);
}
