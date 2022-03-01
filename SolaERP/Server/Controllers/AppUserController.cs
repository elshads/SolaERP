namespace SolaERP.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class AppUserController : ControllerBase
    {
        AppUserService _appUserService;

        public AppUserController(AppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<AppUser> GetCurrentUserAsync()
        {
            return await _appUserService.GetCurrentUserAsync();
        }
    }
}