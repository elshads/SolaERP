
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
            var sql = "dbo.SP_GroupMain_Load";
            var p = new DynamicParameters();
            var groupList = await _groupService.GetAllAsync(sql, p, CommandType.StoredProcedure);
            return groupList.ResultList;
        }
    }
}
