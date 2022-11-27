using Database.Models;

namespace Database.Repositories
{
    public interface IRepositoryWrapper
    {
        IRepository<Employee> Employees { get; }
        IRepository<Department> Departments { get; }
        IRepository<IdentifierDocument> Documents { get; }
        IRepository<Relative> Relatives { get; }
        IRepository<Relationship> Relationships { get; }
        IRepository<Workplace> Workplaces { get; }
        IRepository<RankAssignment> RankAssignments { get; }
        IRepository<PositionAssignment> PositionAssignments { get; }
        IRepository<Education> Educations { get; }
        IRepository<Certificate> Certificates { get; }
    }
}
