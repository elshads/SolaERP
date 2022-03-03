namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BusinessUnitController : ControllerBase
{
    BusinessUnitService _businessUnitService;

    public BusinessUnitController(BusinessUnitService businessUnitService)
    {
        _businessUnitService = businessUnitService;
    }

    [HttpGet]
    public async Task<IEnumerable<BusinessUnit>> GetAllAsync()
    {
        return await _businessUnitService.GetAllAsync();
    }
}
