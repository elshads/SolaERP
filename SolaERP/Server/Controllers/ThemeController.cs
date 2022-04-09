namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ThemeController : ControllerBase
{
    int _currentUserId;
    ThemeService _themeService;
    public ThemeController(AppUserService appUserService, ThemeService themeService)
    {
        _currentUserId = appUserService.GetCurrentUserId();
        _themeService = themeService;
    }

    [HttpPut]
    public async Task<SqlResult> UpdateUserTheme([FromBody] string theme)
    {
        return await _themeService.UpdateUserTheme(theme, _currentUserId);
    }
}