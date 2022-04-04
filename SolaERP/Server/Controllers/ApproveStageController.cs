namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ApproveStageController : ControllerBase
{
    ApproveStageService _approveStageService;

    public ApproveStageController(ApproveStageService approveStageService)
    {
        _approveStageService = approveStageService;
    }

    [HttpGet("GetAll")]
    public async Task<IEnumerable<ApproveStage>> GetAll(int id)
    {
        return await _approveStageService.GetAllAsync(id);
    }
}
