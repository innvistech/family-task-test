using Domain.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FamilyTaskContext : DbContext
    {

        public FamilyTaskContext(DbContextOptions<FamilyTaskContext> options) : base(options)
        {

        }

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.ToTable("Member");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.HasKey(k => k.Id);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.ToTable("Task");
            });
        }
    }
}