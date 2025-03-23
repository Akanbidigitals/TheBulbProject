using Microsoft.EntityFrameworkCore;
using TheBulbProject.Domain.Model;

namespace TheBulbProject.DataAccess.DataContext
{
    public class AppDBcontext(DbContextOptions options) : DbContext (options)
    {
        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldResponse> FieldResponses { get; set; }
        public DbSet<Profile> Profiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Form>()
                .HasMany(f => f.Fields)
                .WithOne()
                .HasForeignKey(f => f.FormID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Form>()
                .HasMany(f => f.Responses);
                //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Field>()
                .HasMany(f => f.FieldResponses)
                .WithOne()
                .HasForeignKey(f => f.FieldID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FieldResponse>()
                .HasIndex(r => r.SubmisionID);

            modelBuilder.Entity<Profile>()
                .HasKey(f => f.Id);
            
        }
    }
}
