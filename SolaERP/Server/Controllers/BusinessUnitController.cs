namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BusinessUnitController : ControllerBase
{
    AppUserService _appUserService;
    BusinessUnitService _businessUnitService;

    public BusinessUnitController(AppUserService appUserService, BusinessUnitService businessUnitService)
    {
        _appUserService = appUserService;
        _businessUnitService = businessUnitService;
    }

    [HttpGet]
    public async Task<IEnumerable<BusinessUnit>> GetByUserIdAsync()
    {
        var currenUser = await _appUserService.GetCurrentUserAsync();
        return await _businessUnitService.GetByUserIdAsync(currenUser.Id);
    }
}
