using Shared.Enums;
using Shared.Models;

namespace Logic.Services
{
    public interface IDepartmentService : IServiceBase
    {
        public Task<IEnumerable<DepartmentShort>> GetAllAsync();

        public Task<IEnumerable<DepartmentShortWithGroupFlag>> GetSubAsync(string departmentId);

        public Task<IEnumerable<DepartmentShortWithGroupFlag>> GetRootAsync(DepartmentType departmentType);

        public Task<IEnumerable<EmployeeShort>> GetEmployeesByDepartmentAsync(string departmentId);
    }
}