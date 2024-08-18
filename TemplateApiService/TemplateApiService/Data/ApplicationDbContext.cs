using Microsoft.EntityFrameworkCore;
using TemplateApiService.Models.Users;

namespace TemplateApiService.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("true");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("timezone('utc'::text, now())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
