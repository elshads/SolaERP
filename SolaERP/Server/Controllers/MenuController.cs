namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]

public class MenuController : ControllerBase
{
    MenuService _menuService;

    public MenuController(MenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpPost]
    public async Task<IEnumerable<Menu>> GetUserMenuAsync([FromBody] AppUser user)
    {
        return await _menuService.GetUserItemsAsync(user.Id);
    }
}