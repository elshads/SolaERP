namespace SolaERP.Server.ModelService;

public class MenuService
{
    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        IEnumerable<Menu> result = new List<Menu>();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"SELECT * FROM VW_Menus_list";
                var _result = await cn.QueryAsync<Menu>(sql);
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

    public async Task<Menu> GetByIdAsync(int id)
    {
        var result = new Menu();
        try
        {
            using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
            {
                var sql = $"SELECT * FROM VW_Menus_list WHERE MenuId = {id}";
                var _result = await cn.QueryAsync<Menu>(sql);
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
