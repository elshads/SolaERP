namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ThemeController : ControllerBase
{
    int _currentUserId;
    public ThemeController(AppUserService appUserService)
    {
        _currentUserId = appUserService.GetCurrentUserId();
    }
    [HttpPut]
    public async Task<SqlResult> UpdateUserTheme([FromBody] string theme)
    {
        var result = new SqlResult();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = "UPDATE Config.AppUser SET Theme = @Theme WHERE Id = @Id";
                result.UpdatedResult = await cn.ExecuteAsync(sql, new { Theme = theme, Id = _currentUserId });
            }
        }
        catch (Exception ex)
        {
            result.UpdatedResultMessage = ex.Message;
        }
        return result;
    }
}