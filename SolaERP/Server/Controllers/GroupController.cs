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
        var sql = $"dbo.SP_GroupMain_Load";
        var p = new DynamicParameters();

        var result = await _groupService.GetAllAsync(sql, p, CommandType.StoredProcedure);
        return result.ResultList;
    }

    [HttpGet]
    public async Task<Group> GetByIdAsync([FromBody] Group group)
    {
        var sql = $"dbo.SP_GroupHeader_Load";
        var p = new DynamicParameters();
        p.Add("@GroupId", group.GroupId, DbType.Int32, ParameterDirection.Input);

        return await _groupService.GetSingleAsync(sql, p, CommandType.StoredProcedure);
    }

    [HttpDelete]
    public async Task<SqlResult> DeleteAsync([FromBody] List<int> deleteList)
    {
        var sql = $"dbo.SP_Groups_IUD";
        return await _groupService.DeleteAsync(deleteList, sql, "GroupId");
    }

    [HttpPost]
    public async Task<SqlResult> InsertAsync([FromBody] List<Group> groups)
    {
        var sql = $"dbo.SP_Groups_IUD";
        return await _groupService.InsertAsync(groups, sql);
    }
}