using FormulaOne.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Entities.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Achievement>(achievement =>
            {
                achievement
                    .HasOne(a => a.Driver)
                    .WithMany(d  => d.Achievements)
                    .HasForeignKey(a => a.DriverId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Achivement_Driver");
            });
        }
    }
}
