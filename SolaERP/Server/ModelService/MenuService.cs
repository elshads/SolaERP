
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

    public async Task<IEnumerable<Menu>> GetUserItemsAsync(int userId)
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
                    result = GetHierarchy(_result);
                }
            }
        }
        catch (Exception e)
        {
            var message = e.Message;
        }
        return result;
    }

    public IEnumerable<Menu> GetHierarchy(IEnumerable<Menu> flatList)
    {
        var tempList = flatList.Where(e => e.ParentId == null || e.ParentId == 0).Select(e => new Menu
        {
            MenuId = e.MenuId,
            ParentId = e.ParentId,
            MenuCode = e.MenuCode,
            MenuName = e.MenuName,
            URL = e.URL,
            Icon = (e.Icon != null ? Icons.Filled.GetType().GetProperty(e.Icon)?.GetValue(Icons.Filled, null).ToString() : ""),
            Children = GetCildren(flatList, e.MenuId)
        });
        return tempList;
    }

    IEnumerable<Menu> GetCildren(IEnumerable<Menu> flatList, int parentId)
    {
        var tempList = flatList.Where(e => e.ParentId == parentId).Select(e => new Menu
        {
            MenuId = e.MenuId,
            ParentId = e.ParentId,
            MenuCode = e.MenuCode,
            MenuName = e.MenuName,
            URL = e.URL,
            Icon = (e.Icon != null ? Icons.Filled.GetType().GetProperty(e.Icon)?.GetValue(Icons.Filled, null).ToString() : ""),
            Children = GetCildren(flatList, e.MenuId)
        });
        return tempList;
    }
}
