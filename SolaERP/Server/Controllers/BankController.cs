namespace SolaERP.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        BankService _bankService;
        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Bank>> GetAll()
        {
            return await _bankService.GetAll();
        }
    }
}
