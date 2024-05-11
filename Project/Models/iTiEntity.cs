using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class iTiEntity : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6C96F26\\MSSQLSERVER01;initial catalog=ITIDB;Integrated Security=True;trustservercertificate=true");
        }
    }
}
