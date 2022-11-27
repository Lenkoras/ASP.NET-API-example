using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private IEducationService educationService;

        public EducationController(IEducationService educationService)
        {
            this.educationService = educationService;
        }

        [HttpGet("{educationId}")]
        [ProducesResponseType(typeof(EducationFull), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string educationId) =>
            Ok(await educationService.GetByIdAsync(educationId));
    }
}
