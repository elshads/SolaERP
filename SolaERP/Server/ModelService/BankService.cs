namespace SolaERP.Server.ModelService
{
    public class BankService
    {
        string? _connectionString;
        public BankService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

        public async Task<IEnumerable<Bank>> GetAll()
        {
            IEnumerable<Bank> result = new List<Bank>();
            try
            {
                var view = "BankCodesList";
                using (var cn = new SqlConnection(_connectionString))
                {
                    var _result = await cn.QueryAsync<Bank>($"SELECT * FROM dbo.{view}");
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
