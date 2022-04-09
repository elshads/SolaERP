namespace SolaERP.Server.ModelService;
public class ThemeService
{
    string? _connectionString;
    public ThemeService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

    public async Task<SqlResult> UpdateUserTheme(string theme, int userId)
    {
        var result = new SqlResult();
        try
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Config.AppUser SET Theme = @Theme WHERE Id = @Id";
                result.UpdatedResult = await cn.ExecuteAsync(sql, new { Theme = theme, Id = userId });
            }
        }
        catch (Exception ex)
        {
            result.UpdatedResultMessage = ex.Message;
        }
        return result;
    }
}
