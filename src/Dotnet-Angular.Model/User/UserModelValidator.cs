using FluentValidation;

namespace Dotnet_Angular.Model;

public abstract class UserModelValidator : AbstractValidator<UserModel>
{
    public void Id() => RuleFor(user => user.Id).NotEmpty();

    public void FirstName() => RuleFor(user => user.FirstName).NotEmpty();
    public void Place() => RuleFor(user => user.Place).NotEmpty();

    public void Email() => RuleFor(user => user.Email).EmailAddress();

    public void LastName() => RuleFor(user => user.LastName).NotEmpty();

}
