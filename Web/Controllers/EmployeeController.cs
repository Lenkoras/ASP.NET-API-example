using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

#if !RELEASE
        /// <summary>
        /// Доступно только для тестов.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmployeeShort>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await employeeService.GetAllAsync());
#endif

        [HttpGet("{employeeId}")]
        [ProducesResponseType(typeof(EmployeeFull), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetByIdAsync(employeeId));

        [HttpGet("Search")]
        [ProducesResponseType(typeof(SearchResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchAsync([FromQuery][MinLength(2)][MaxLength(60)] string? q) =>
           Ok(await employeeService.SearchAsync(q));

        [HttpGet("{employeeId}/Departments")]
        [ProducesResponseType(typeof(DepartmentsEnumeration), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDepartmentsAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetDepartmentsAsync(employeeId));

        [HttpGet("{employeeId}/Document")]
        [ProducesResponseType(typeof(DocumentFull), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocumentAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetDocumentAsync(employeeId));

        [HttpGet("{employeeId}/Education")]
        [ProducesResponseType(typeof(EducationFull), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEducationAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetEducationAsync(employeeId));

        [HttpGet("{employeeId}/Family")]
        [ProducesResponseType(typeof(IEnumerable<RelationshipFull>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFamilyAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetFamilyAsync(employeeId));

        [HttpGet("{employeeId}/Workplace")]
        [ProducesResponseType(typeof(IEnumerable<WorkplaceFull>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWorkplaceAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetWorkplaceAsync(employeeId));

        /// <summary>
        /// Получить информацию о звании и ФИО военнослужащего по указанному идентификатору.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("{employeeId}/RankedName")]
        [ProducesResponseType(typeof(RankedNameInfo), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindRankedNameAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.FindRankedNameAsync(employeeId));

        [HttpGet("{employeeId}/Assignment")]
        [ProducesResponseType(typeof(AssignmentFull), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssignmentsAsync([FromRoute] string employeeId) =>
            Ok(await employeeService.GetAssignmentsAsync(employeeId));
    }
}