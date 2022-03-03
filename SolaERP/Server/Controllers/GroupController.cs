namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class GroupController : Controller
{
    GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        return await _groupService.GetAllAsync();
    }
}
