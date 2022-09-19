namespace Dotnet_Angular.Model;

public sealed class UpdateUserModelValidator : UserModelValidator
{
    public UpdateUserModelValidator()
    {
        Id(); FirstName(); LastName(); Email();
        Place();
    }
}
