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

        public virtual DbSet<RewardStrategy> RewardStrategies { get; set; }

        public virtual DbSet<DeadlineStrategy> DeadlineStrategies { get; set; }


        public static PhotoDbContext Create()
        {
            return new PhotoDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Contests)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ParticipantId");
                    m.MapRightKey("ContestId");
                    m.ToTable("ParticipantsContests");
                });

            modelBuilder.Entity<Picture>()
               .HasMany(u => u.Contests)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("PictureId");
                   m.MapRightKey("ContestId");
                   m.ToTable("PicturesContests");
               });

            base.OnModelCreating(modelBuilder);
        }
        
    }
}

