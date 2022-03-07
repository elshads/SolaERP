namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserMenuAccessController : Controller
{
    UserMenuAccessService _userMenuAccessService;

    public UserMenuAccessController(UserMenuAccessService userMenuAccessService)
    {
        _userMenuAccessService = userMenuAccessService;
    }

    [HttpGet]
    public async Task<List<UserMenuAccess>> GetByIdAsync(AppUser appUser)
    {
        return await _userMenuAccessService.GetByIdAsync(appUser.Id);
    }
}