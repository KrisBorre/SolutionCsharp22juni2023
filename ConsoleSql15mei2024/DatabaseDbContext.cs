using Microsoft.EntityFrameworkCore;

namespace ConsoleSql15mei2024
{
    public class DatabaseDbContext : DbContext
    {
        // The following configures EF to create a Sqlite database file in the
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=../../../../database15mei2024.db");

    }
}
