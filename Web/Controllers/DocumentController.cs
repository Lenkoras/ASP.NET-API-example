using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService documentService;
        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpGet("{documentId}")]
        [ProducesResponseType(typeof(DocumentFull), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string documentId) =>
            Ok(await documentService.GetByIdAsync(documentId));
    }
}
