namespace SolaERP.Server.ModelService;

public class GroupService
{
    string? _connectionString;
    public GroupService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        IEnumerable<Group> result = new List<Group>();
        try
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                var _result = await cn.QueryAsync<Group>("dbo.SP_GroupMain_Load", commandType: CommandType.StoredProcedure);
                if (_result.Any()) result = _result;
            }
        }
        catch (Exception e)
        {
            var message = e.Message;
        }
        return result;
    }
}
