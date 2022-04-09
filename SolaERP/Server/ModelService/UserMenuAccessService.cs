namespace SolaERP.Server.ModelService;

public class UserMenuAccessService
{
    string? _connectionString;
    public UserMenuAccessService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

    public async Task<List<UserMenuAccess>> GetByIdAsync(int _userId)
    {
        List<UserMenuAccess>? result = new();

        try
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                var sql = $"dbo.SP_UserMenuAccess";
                var values = new { UserId = _userId };
                var _result = await cn.QueryAsync<UserMenuAccess>(sql, values, commandType: CommandType.StoredProcedure);
                if (_result != null)
                {
                    result = _result.ToList();
                }
            }
        }
        catch (Exception e)
        {
            result.Add(new UserMenuAccess { ReturnMessage = e.Message, MenuId = -1, UserId = _userId });
        }

        return result;
    }
}
