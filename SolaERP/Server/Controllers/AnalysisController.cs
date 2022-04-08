namespace SolaERP.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {
        AnalysisService _analysisService;
        public AnalysisController(AnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        [HttpGet("GetExpense")]
        public async Task<IEnumerable<Analysis>> GetExpense()
        {
            return await _analysisService.GetAll(1);
        }

        [HttpGet("GetGroupProject")]
        public async Task<IEnumerable<Analysis>> GetGroupProject()
        {
            return await _analysisService.GetAll(2);
        }

        [HttpGet("GetProject")]
        public async Task<IEnumerable<Analysis>> GetProject()
        {
            return await _analysisService.GetAll(3);
        }
    }
}
