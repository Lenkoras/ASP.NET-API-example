using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;
using Shared.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentShortWithGroupFlag>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] DepartmentType? type) =>
            Ok(await departmentService.GetRootAsync(type.HasValue ? type.Value : DepartmentType.None));

        [HttpGet("{departmentId}")]
        [ProducesResponseType(typeof(IEnumerable<DepartmentShortWithGroupFlag>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string departmentId) =>
            Ok(await departmentService.GetSubAsync(departmentId));

        [HttpGet("{departmentId}/employees")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeShort>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeesByDepartmentAsync(string departmentId) =>
            Ok(await departmentService.GetEmployeesByDepartmentAsync(departmentId));
    }
}
