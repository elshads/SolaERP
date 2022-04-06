namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AttachmentController : ControllerBase
{
    AttachmentService _attachmentService;

    public AttachmentController(AttachmentService attachmentService)
    {
        _attachmentService = attachmentService;
    }


    [HttpGet("GetByIdAsync")]
    public async Task<Attachment> GetByIdAsync(int id)
    {
        return await _attachmentService.GetByIdAsync(id);
    }

}
