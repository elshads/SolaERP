namespace SolaERP.Server.ModelService
{
    public class VendorService
    {
        string? _connectionString;
        public VendorService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

        public async Task<IEnumerable<Vendor>> GetAllAsync(int businessUnitId)
        {
            IEnumerable<Vendor> result = new List<Vendor>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@BusinessUnitId", businessUnitId, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<Vendor>("dbo.SP_VendorList", p, commandType: CommandType.StoredProcedure);
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
}
