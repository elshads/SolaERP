namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserAccessController : Controller
{
    UserAccessService _userAccessService;

    public UserAccessController(UserAccessService userAccessService)
    {
        _userAccessService = userAccessService;
    }

    [HttpGet]
    public async Task<List<UserMenuAccess>> GetByIdAsync(AppUser appUser)
    {
        return await _userAccessService.GetByIdAsync(appUser.Id);
    }
}