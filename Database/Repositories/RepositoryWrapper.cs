using Database.Models;

namespace Database.Repositories
{
    public partial class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext context;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<Employee> Employees => BuildRepository<Employee>();
        public IRepository<Department> Departments => BuildRepository<Department>();
        public IRepository<IdentifierDocument> Documents => BuildRepository<IdentifierDocument>();
        public IRepository<Relative> Relatives => BuildRepository<Relative>();
        public IRepository<Relationship> Relationships => BuildRepository<Relationship>();
        public IRepository<Workplace> Workplaces => BuildRepository<Workplace>();
        public IRepository<RankAssignment> RankAssignments => BuildRepository<RankAssignment>();
        public IRepository<PositionAssignment> PositionAssignments => BuildRepository<PositionAssignment>();
        public IRepository<Education> Educations => BuildRepository<Education>();
        public IRepository<Certificate> Certificates => BuildRepository<Certificate>();

        private IRepository<TEntity> BuildRepository<TEntity>() 
            where TEntity : class, IEntity =>
            new Repository<TEntity, ApplicationDbContext>(context);
    }
}
