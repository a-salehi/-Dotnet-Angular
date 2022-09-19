namespace Dotnet_Angular.Model;

public sealed record UserModel
{
    public long Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Place { get; init; } = null!;
    public string Email { get; init; } = null!;
}
