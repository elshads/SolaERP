namespace SolaERP.Server.ModelService
{
    public class BankService
    {
        public async Task<IEnumerable<Bank>> GetAll()
        {
            IEnumerable<Bank> result = new List<Bank>();
            try
            {
                var view = "BankCodesList";
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
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
