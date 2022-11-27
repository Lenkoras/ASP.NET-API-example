using AutoMapper;
using Database.Models;
using Database.Repositories;
using Shared.Enums;
using Shared.Models;

namespace Logic.Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        public IRepository<Employee> Repository => RepositoryWrapper.Employees;

        public EmployeeService(IRepositoryWrapper repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<EmployeeFull?> GetByIdAsync(string employeeId)
        {
            var employee = await Repository.FindAsync(employeeId);
            if (employee != null && employee.IsVisible)
            {
                return Map<EmployeeFull>(employee);
            }
            return null;
        }

#if !RELEASE
        public async Task<IEnumerable<EmployeeShort>> GetAllAsync()
        {
            var employees = await Repository.WhereAsync(employee => employee.IsVisible);
            return Mapper.Map<IEnumerable<EmployeeShort>>(employees);
        }
#endif

        public async Task<DocumentFull?> GetDocumentAsync(string employeeId) =>
            Map<DocumentFull>(
                await FindAsync(Repository, employeeId,
                employee => employee.Document));

        public async Task<IEnumerable<EducationFull>> GetEducationAsync(string employeeId) =>
            Map<IEnumerable<EducationFull>>(
                await FindAsync(Repository, employeeId,
                employee => employee.Educations));

        public async Task<IEnumerable<RelationshipFull>> GetFamilyAsync(string employeeId) =>
            Map<IEnumerable<RelationshipFull>>(
                await FindAsync(Repository, employeeId,
                employee => employee.Relationships.OrderBy(rs => rs.Type)));

        public async Task<IEnumerable<WorkplaceFull>> GetWorkplaceAsync(string employeeId) =>
            Map<IEnumerable<WorkplaceFull>>(
                await FindAsync(Repository, employeeId,
                employee => employee.Workplaces));

        public async Task<AssignmentFull> GetAssignmentsAsync(string employeeId) =>
            await FindAsync(Repository, employeeId, GetLastAssignments);

        public async Task<SearchResult> SearchAsync(string? employeeFullName)
        {
            if (employeeFullName == null || employeeFullName.Any(IsNotLetterOrDigitOrWhiteSpace))
            {
                return SearchResult.Empty;
            }
            int key = 0;
            var names = employeeFullName
                .ToLower()
                .Trim()
                .Split(WordSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Where(ValueLengthMoreThanMinValueLength)
                .ToDictionary(value => key++);
            
            if (names.Count < 1 || names.Any(name => name.Value.Length > 20))
            {
                return SearchResult.Empty;
            }

            /*
             //static bool Contains(string value, params string[] values) => values.Contains(value); // as global
             var emps = Repository.Where(employee => employee.IsVisible && desireds.Any(desiredValue => Contains(desiredValue, employee.FirstName, employee.LastName, employee.MiddleName)));
            */

            // Pretty nice implementation 'can not be translated to sql', so..

            // instead of an array
            names.TryGetValue(0, out var word1);
            names.TryGetValue(1, out var word2);
            names.TryGetValue(2, out var word3);

            var emps = await Repository.WhereAsync(employee =>
            employee.IsVisible && (
            employee.FirstName != null && employee.FirstName.Contains(word1!) ||
            (employee.LastName != null && employee.LastName.Contains(word1!)) ||
            (employee.MiddleName != null && employee.MiddleName.Contains(word1!)) ||

            word2 != null && (
            employee.FirstName != null && employee.FirstName.Contains(word2) ||
            (employee.LastName != null && employee.LastName.Contains(word2)) ||
            (employee.MiddleName != null && employee.MiddleName.Contains(word2))) ||

            word3 != null && (
            employee.FirstName != null && employee.FirstName.Contains(word3) ||
            (employee.LastName != null && employee.LastName.Contains(word3)) ||
            (employee.MiddleName != null && employee.MiddleName.Contains(word3)))));

            List<Guid> deps = new();

            foreach (var emp in emps)
            {
                var dep = emp.Department;
                while (dep != null)
                {
                    deps.Add(dep.Id);
                    dep = dep.ParentDepartment;
                }
            }

            return new SearchResult()
            {
                Departments = deps.Distinct().Select(ToString),
                Employees = emps.Select(EmployeeIdToString)
            };
        }

        public Task<DepartmentsEnumeration?> GetDepartmentsAsync(string employeeId) =>
             FindAsync(Repository, employeeId, employee => BuildDepartmentsEnumeration(employee.Department));

        public async Task<RankedNameInfo> FindRankedNameAsync(string employeeId) =>
            await FindAsync(Repository, employeeId, 
                employee => new RankedNameInfo() { 
                    Rank = FindLastAssignmentByDate(employee.RankAssignments).Rank, 
                    FullName = Employee.FullName(employee) 
                });

        private DepartmentsEnumeration? BuildDepartmentsEnumeration(Department? department)
        {
            if (department == null)
            {
                return null;
            }
            var deps = new DepartmentsEnumeration();

            while (department != null)
            {
                switch (department.Type)
                {
                    case DepartmentType.Faculty:
                        deps.Faculty = Map<DepartmentShort>(department);
                        break;
                    case DepartmentType.Course:
                        deps.Course = Map<DepartmentShort>(department);
                        break;
                    case DepartmentType.Group:
                        deps.Group = Map<DepartmentShort>(department);
                        break;
                }
                department = department.ParentDepartment;
            }
            return deps;
        }

        private AssignmentFull GetLastAssignments(Employee entity) =>
            new()
            {
                Position = Map<PositionAssignmentFull>(FindLastAssignmentByDate(entity.PositionAssignments)),
                Rank = Map<RankAssignmentFull>(FindLastAssignmentByDate(entity.RankAssignments))
            };

        private static TAssignment CompairAssignmentsByDate<TAssignment>(TAssignment current, TAssignment next)
            where TAssignment : AssignmentBase =>
            (current == null && next != null) || current != null && next != null && current.Date < next.Date ? next : current!;

        private static TAssignment FindLastAssignmentByDate<TAssignment>(IEnumerable<TAssignment> assignments)
            where TAssignment : AssignmentBase =>
            assignments.Aggregate(default(TAssignment)!, CompairAssignmentsByDate<TAssignment>);

        private static string EmployeeIdToString(Employee employee) =>
            ToString(employee.Id);

        private static bool IsNotLetterOrDigitOrWhiteSpace(char character) => !(char.IsLetterOrDigit(character) || char.IsWhiteSpace(character));

        private static bool ValueLengthMoreThanMinValueLength(string value)
        {
            const int MinValueLength = 1;

            return value.Length > MinValueLength;
        }

        private static string ToString<T>(T value) =>
            value?.ToString()!;

        private static string[] WordSeparator = new string[] { " " };
    }
}
