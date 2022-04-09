namespace SolaERP.Server.ModelService;

public class BaseService<T> where T : IBaseModel, new()
{
    public string? ConnectionString { get; set; }
    public BaseService(SqlDataAccess sqlDataAccess) => ConnectionString = sqlDataAccess.ConnectionString;
}