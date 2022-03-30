namespace SolaERP.Server.ModelService;

public class BusinessUnitService
{
    public async Task<IEnumerable<BusinessUnit>> GetAllAsync()
    {
        IEnumerable<BusinessUnit> result = new List<BusinessUnit>();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"SELECT * FROM VW_BusinessUnits_List";
                var _result = await cn.QueryAsync<BusinessUnit>(sql);
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

    public async Task<IEnumerable<BusinessUnit>> GetByUserIdAsync(int userId)
    {
        IEnumerable<BusinessUnit> result = new List<BusinessUnit>();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);
                var _result = await cn.QueryAsync<BusinessUnit>("dbo.SP_UserBusinessUnitsList", p, commandType: CommandType.StoredProcedure);
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
