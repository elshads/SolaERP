
namespace SolaERP.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]

    public class GroupController : ControllerBase
    {
        GroupService _groupService;
        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _groupService.GetAllAsync();
        }
    }
}
