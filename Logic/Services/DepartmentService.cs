using AutoMapper;
using Database.Models;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Models;

namespace Logic.Services
{
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        public IRepository<Department> Repository => RepositoryWrapper.Departments;

        public DepartmentService(IRepositoryWrapper repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<DepartmentShort>> GetAllAsync() =>
            Map<IEnumerable<DepartmentShort>>(
                await Repository.ToArrayAsync());

        public async Task<IEnumerable<EmployeeShort>> GetEmployeesByDepartmentAsync(string departmentId) =>
            Map<IEnumerable<EmployeeShort>>(
                await FindAsync(Repository, departmentId, department => department.Employees))
                    .OrderBy(employee => employee.FullName);

        public async Task<IEnumerable<DepartmentShortWithGroupFlag>> GetRootAsync(DepartmentType departmentType) =>
            Map<IEnumerable<DepartmentShortWithGroupFlag>>(
                departmentType != DepartmentType.None ?
                    await Repository.WhereAsync(department => department.ParentDepartment == null && department.Type == departmentType) :
                    await Repository.WhereAsync(department => department.ParentDepartment == null));

        public async Task<IEnumerable<DepartmentShortWithGroupFlag>> GetSubAsync(string departmentId) =>
            Map<IEnumerable<DepartmentShortWithGroupFlag>>(
                await FindAsync(Repository, departmentId, department => department.SubDepartment))
                    .OrderBy(department => department.Name);
    }
}
