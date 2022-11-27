using Shared.Models;

namespace Logic.Services
{
    public interface IEmployeeService : IServiceBase
    {
#if !RELEASE
        Task<IEnumerable<EmployeeShort>> GetAllAsync();
#endif
        Task<EmployeeFull?> GetByIdAsync(string employeeId);

        Task<DepartmentsEnumeration?> GetDepartmentsAsync(string employeeId);

        Task<DocumentFull?> GetDocumentAsync(string employeeId);

        Task<IEnumerable<EducationFull>> GetEducationAsync(string employeedId);

        Task<IEnumerable<RelationshipFull>> GetFamilyAsync(string employeedId);

        Task<IEnumerable<WorkplaceFull>> GetWorkplaceAsync(string employeeId);

        Task<AssignmentFull> GetAssignmentsAsync(string employeeId);

        Task<RankedNameInfo> FindRankedNameAsync(string employeeId);

        Task<SearchResult> SearchAsync(string? employeeName);

    }
}
