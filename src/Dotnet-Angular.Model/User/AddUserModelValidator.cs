namespace Dotnet_Angular.Model;

public sealed class AddUserModelValidator : UserModelValidator
{
    public AddUserModelValidator()
    {
        FirstName(); LastName(); Email();
        Place();
    }
}
