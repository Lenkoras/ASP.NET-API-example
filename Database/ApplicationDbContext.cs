using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<IdentifierDocument> Documents { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<PositionAssignment> PositionAssignments { get; set; }

        public DbSet<RankAssignment> RankAssignments { get; set; }

        public DbSet<Relative> Relatives { get; set; }

        public DbSet<Relationship> RelationShips { get; set; }

        public DbSet<Workplace> Workplaces { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<Education> Educations { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
