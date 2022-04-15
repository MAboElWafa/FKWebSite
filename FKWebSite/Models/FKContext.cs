using Microsoft.EntityFrameworkCore;

namespace FKWebSite.Models
{
    public class FKContext : DbContext
    {
        public FKContext(DbContextOptions<FKContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<RecommendedTB> RecommendedTBs { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Delegate> Delegates { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Memory> Memorys { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
