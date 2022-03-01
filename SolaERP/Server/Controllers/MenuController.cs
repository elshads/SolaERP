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

    [HttpGet]
    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        return await _menuService.GetAllAsync();
    }
}