namespace SolaERP.Server.ModelService;

public class AttachmentService
{
    string? _connectionString;
    public AttachmentService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

    public async Task<Attachment> GetByIdAsync(int id)
    {
        Attachment result = new();
        try
        {
            using (var cn = new SqlConnection(_connectionString))
            {
                var p = new DynamicParameters();
                p.Add("@AttachmentId", id, DbType.Int32, ParameterDirection.Input);
                var _result = await cn.QueryAsync<Attachment>("dbo.SP_Attachment_Load", p, commandType: CommandType.StoredProcedure);
                if (_result.Any()) result = _result.FirstOrDefault();
            }
        }
        catch (Exception e)
        {
            result.ReturnMessage = e.Message;
        }
        return result;
    }
}
