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

    public async Task<BusinessUnit> GetByIdAsync(int id)
    {
        var result = new BusinessUnit();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"SELECT * FROM VW_BusinessUnits_List WHERE BusinessUnitId = {id}";
                var _result = await cn.QueryAsync<BusinessUnit>(sql);
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
