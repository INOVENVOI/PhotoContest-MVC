using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoContext.Models;

public class PhotoDbContext : IdentityDbContext<User>
{
    public PhotoDbContext()
        : base("PhotoContext")
    {
    }

    public DbSet<Picture> Pictures { get; set; }

    public static PhotoDbContext Create()
    {
        return new PhotoDbContext();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User creates Contest

        modelBuilder.Entity<User>()
            .HasMany(u => u.CreatedContests)
            .WithRequired(c => c.Organizator)
            .HasForeignKey(c => c.UserId)
            .WillCascadeOnDelete(false);

        // Contest has users

        modelBuilder.Entity<Contest>()
            .HasMany(c => c.JoinedInUsers)
            .WithMany(u => u.JoinedContests)
            .Map(m =>
            {
                m.MapLeftKey("ContestId");
                m.MapRightKey("UserId");
                m.ToTable("UsersInContests");
            });

        // Users has pictures

        modelBuilder.Entity<User>()
            .HasMany(u => u.Pictures)
            .WithRequired(p => p.Owner)
            .HasForeignKey(p => p.UserId)
            .WillCascadeOnDelete(false);

        // Picture with pictures in contests

        modelBuilder.Entity<Picture>()
            .HasRequired(p => p.PicturesInContests)
            .WithMany(pic => pic.Pictures)
            .HasForeignKey(p => p.Id)
            .WillCascadeOnDelete(false);

        // Contest with pictures in contests

        modelBuilder.Entity<Contest>()
            .HasRequired(c => c.PicturesInContests)
            .WithMany(pic => pic.Contests)
            .HasForeignKey(p => p.Id)
            .WillCascadeOnDelete(false);

        // Vote pictures
            
        modelBuilder.Entity<Vote>()
            .HasRequired(v => v.User)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.UserId)
            .WillCascadeOnDelete(false);

        // Vote PicturesInContests

        modelBuilder.Entity<Vote>()
            .HasRequired(v => v.PicturesInContests)
            .WithMany(pic => pic.Votes)
            .HasForeignKey(v => v.PicturesInContestsId)
            .WillCascadeOnDelete(false);
    }
}