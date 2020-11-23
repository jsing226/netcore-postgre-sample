using Microsoft.EntityFrameworkCore;

namespace SamplePostgre.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Employee> Employees{get;set;}
    }
}
