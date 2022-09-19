using DotNetCore.Domain;

namespace Dotnet_Angular.Domain;

public class User : Entity<long>
{
    public User
    (
        Name name,
        Email email,
        Place place
    )
    {
        Name = name;
        Email = email;
        Place = place;
        Activate();
    }

    public User(long id) => Id = id;

    public Name Name { get; private set; } = null!;

    public Email Email { get; private set; } = null!;

    public Status Status { get; private set; }

    public Place Place { get; private set; } = null!;

    public void Activate()
    {
        Status = Status.Active;
    }

    public void Inactivate()
    {
        Status = Status.Inactive;
    }

    public void Update(string firstName, string lastName, string email, string place)
    {
        Name = new Name(firstName, lastName);
        Email = new Email(email);
        Place = new Place(place);
    }
}
