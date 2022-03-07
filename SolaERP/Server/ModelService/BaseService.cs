namespace SolaERP.Server.ModelService;

public class BaseService<T> where T : BaseModel, new()
{
    public async Task<(IEnumerable<T> ResultList, string ReturnMessage)> GetAllAsync(string sql, DynamicParameters dynamicParameters, CommandType commandType)
    {
        List<T>? result = new();
        string message = string.Empty;

        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var _result = await cn.QueryAsync<T>(sql, dynamicParameters, commandType: commandType);
                if (_result != null)
                {
                    result = _result.ToList();
                }
            }
        }
        catch (Exception e)
        {
            message = e.Message;
        }

        return (result, message);
    }

    public async Task<T> GetSingleAsync(string sql, DynamicParameters dynamicParameters, CommandType commandType)
    {
        T? result = new();

        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var _result = await cn.QueryAsync<T>(sql, dynamicParameters, commandType: commandType);
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

    public async Task<SqlResult> DeleteAsync(List<int> deleteList, string sql, string idColumnName)
    {
        SqlResult? result = new();

        try
        {
            foreach (var deleteId in deleteList)
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add(idColumnName, deleteId, DbType.Int32, ParameterDirection.Input);
                    int _result = await cn.ExecuteAsync(sql, dynamicParameters, commandType: CommandType.StoredProcedure);
                    result.DeletedResult += _result > 0 ? _result : 0;
                }
            }
        }
        catch (Exception e)
        {
            result.DeletedResultMessage = e.Message;
        }

        return result;
    }

    public async Task<SqlResult> InsertAsync(List<T> itemList, string sql, DynamicParameters dynamicParameters)
    {
        SqlResult? result = new();

        try
        {
            foreach (var item in itemList)
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    int _result = await cn.ExecuteAsync(sql, dynamicParameters, commandType: CommandType.StoredProcedure);
                    result.InsertedResult += _result > 0 ? _result : 0;
                }
            }
        }
        catch (Exception e)
        {
            result.InsertedResultMessage = e.Message;
        }
        return result;
    }
}
