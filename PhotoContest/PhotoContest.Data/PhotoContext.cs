using Microsoft.AspNet.Identity.EntityFramework;
using PhotoContext.Models;

public class PhotoDbContext : IdentityDbContext<User>
{
    public PhotoDbContext()
        : base("PhotoContext", throwIfV1Schema: false)
    {
    }

    public static PhotoDbContext Create()
    {
        return new PhotoDbContext();
    }
}