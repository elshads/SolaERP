namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ThemeController : Controller
{
    [HttpPut]
    public async Task<SqlResult> UpdateUserTheme([FromBody]AppUser user)
    {
        var result = new SqlResult();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = "UPDATE Config.AppUser SET Theme = @Theme WHERE Id = @Id";
                result.UpdatedResult = await cn.ExecuteAsync(sql, user);
            }
        }
        catch (Exception ex)
        {
            result.UpdatedResultMessage = ex.Message;
        }
        return result;
    }
}