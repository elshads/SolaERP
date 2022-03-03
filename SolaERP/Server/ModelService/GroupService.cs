namespace SolaERP.Server.ModelService;

public class GroupService
{
    public async Task<IEnumerable<Group>> GetAllAsync()
    {
        IEnumerable<Group> result = new List<Group>();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"SELECT * FROM Config.Groups";
                var _result = await cn.QueryAsync<Group>(sql);
                if (_result != null)
                {
                    result = _result;
                }
            }
        }
        catch (Exception e)
        {
            var message = e.Message;
        }
        return result;
    }

    public async Task<Group> GetByIdAsync(int id)
    {
        var result = new Group();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"SELECT * FROM Config.Groups WHERE GroupId = {id}";
                var _result = await cn.QueryAsync<Group>(sql);
                if (_result != null)
                {
                    result = _result.FirstOrDefault();
                }
            }
        }
        catch (Exception e)
        {
            result.ReturnMessage = e.Message;
        }
        return result;
    }
}
