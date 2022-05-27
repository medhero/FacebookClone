using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FacebookClone.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Post> Posts { get; set; }
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasColumnName("UserId");
            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasOptional(u => u.ProfilePicture)
                .WithMany()
                .Map(m => m.MapKey("ProfilePictureId"));
            modelBuilder.Entity<User>()
                .HasRequired(u => u.Gender)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .Property(u => u.DateOfBirth)
                .HasColumnType("Date");


            modelBuilder.Entity<Gender>()
                .Property(p => p.Name)
                .IsRequired();

            base.OnModelCreating(modelBuilder);

        }

        public System.Data.Entity.DbSet<FacebookClone.Models.Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<FacebookClone.Models.Friend> Friends { get; set; }


    }
}