namespace PhotoContest.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoContext.Models;

    public class PhotoDbContext : IdentityDbContext<User>
    {
        public PhotoDbContext()
            : base("PhotoDbContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PhotoDbContext>());
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<PhotoDbContext, PhotoContest.Data.Migrations.Configuration>());
        }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Contest> Contests { get; set; }

        public virtual DbSet<Vote> Votes { get; set; }

        public virtual DbSet<Prize> Prizes { get; set; }


        public static PhotoDbContext Create()
        {
            return new PhotoDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Pictures)
                .WithRequired(p => p.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.OrganizedContests)
                .WithRequired(c => c.Organizer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ParticipatedContests)
                .WithMany(c => c.Participants)
                .Map(m =>
                {
                    m.MapLeftKey("ParticipantId");
                    m.MapRightKey("ContestId");
                    m.ToTable("ContestsParticipants");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Votes)
                .WithRequired(v => v.Voter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contest>()
                .HasMany(c => c.Pictures)
                .WithMany(p => p.Contests)
                .Map(m =>
                {
                    m.MapLeftKey("ContestId");
                    m.MapRightKey("PictureId");
                    m.ToTable("ContestsPictures");
                });

            modelBuilder.Entity<Contest>()
                .HasMany(c => c.Prizes)
                .WithRequired(p => p.Contest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contest>()
                .HasMany(c => c.Votes)
                .WithRequired(v => v.Contest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Picture>()
                .HasMany(p => p.Votes)
                .WithRequired(v => v.Picture)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}

