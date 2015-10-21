using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoContext.Models;

public class PhotoDbContext : IdentityDbContext<User>
{
    public PhotoDbContext()
        : base("PhotoContext")
    {
        Database.SetInitializer(new DropCreateDatabaseAlways<PhotoDbContext>());
    }

    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Contest> Contests { get; set; }
    public DbSet<Vote> Votes { get; set; }

    public static PhotoDbContext Create()
    {
        return new PhotoDbContext();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}