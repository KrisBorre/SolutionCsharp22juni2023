using Microsoft.EntityFrameworkCore;

namespace Education.DataAccessLayer
{
    public class EducationDbContext : DbContext
    {
        // education5apr2024.db will be created in the folder SolutionCsharp22juni2023

        // The following configures EF to create a Sqlite database file in the
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=../../../../education5apr2024.db");

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasKey(p => p.TeacherID);

            modelBuilder.Entity<Teacher>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(a => a.Location)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }

}

