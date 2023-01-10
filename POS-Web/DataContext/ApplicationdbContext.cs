using Microsoft.EntityFrameworkCore;

namespace POS_Web.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        // injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CategoryEntity> CategoryEntities => Set<CategoryEntity>();
        public DbSet<AbsensiEntity> AbsensiEntities => Set<AbsensiEntity>();
        public DbSet<EmployeeEntity> EmployeeEntities => Set<EmployeeEntity>();

    }
}
