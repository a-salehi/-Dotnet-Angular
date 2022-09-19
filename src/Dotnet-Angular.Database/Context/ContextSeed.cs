using Dotnet_Angular.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Angular.Database;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.SeedUsers();
    }

    private static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<User>(user =>
        {
            user.HasData(new
            {
                Id = 1L,
                Status = Status.Active
            });

            user.OwnsOne(userName => userName.Name).HasData(new
            {
                UserId = 1L,
                FirstName = "Amir Hossein",
                LastName = "Salehi"
            });
            
            user.OwnsOne(userPlace => userPlace.Place).HasData(new
            {
                UserId = 1L,
                Value = "Iran"
            });
            
            user.OwnsOne(userEmail => userEmail.Email).HasData(new
            {
                UserId = 1L,
                Value = "amirhossein.salehi@hotmail.com"
            });
        });
    }
}
