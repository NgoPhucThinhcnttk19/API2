using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using API2.Models;
namespace API2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get;set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentsCourses>()
                .HasOne(x => x.student)
                 .WithMany(x => x.StudentsCourses);

            builder.Entity<StudentsCourses>()
                .HasOne(x => x.course)
                .WithMany(x => x.StudentsCourses);

            new DbInitializer(builder).Seed();

        }
    }
}
