using Microsoft.EntityFrameworkCore;
using WebDemo.Context.Model;

namespace WebDemo.Context.ApplicationDb
{

    public class ApplicationDbContext : DbContext
    {
        private string? ConnectionString { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AppSetting appSettings) : base(options)
        {
            ConnectionString = appSettings.WebDemoContext;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Employee>()
        //.Property(e => e.EmployeeCode)
        //.ValueGeneratedNever(); 

        //    base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee>? Employee { get; set; }
    }

}