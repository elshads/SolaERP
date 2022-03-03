namespace SolaERP.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ThemeController : Controller
{
    [HttpPut]
    public async Task<string> UpdateUserTheme([FromBody]AppUser user)
    {
        string result = "User theme saved";
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"UPDATE AppUser SET Theme = {user.Theme} WHERE Id = {user.Id}";
                var _result = await cn.ExecuteAsync(sql);
            }
        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        return result;
    }
}