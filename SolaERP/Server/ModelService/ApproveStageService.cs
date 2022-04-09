namespace SolaERP.Server.ModelService
{
    public class ApproveStageService
    {
        string? _connectionString;
        public ApproveStageService(SqlDataAccess sqlDataAccess) => _connectionString = sqlDataAccess.ConnectionString;

        public async Task<IEnumerable<ApproveStage>> GetAllAsync(int paymentDocumentMainId)
        {
            IEnumerable<ApproveStage> result = new List<ApproveStage>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@PaymentDocumentMainId", paymentDocumentMainId, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<ApproveStage>("dbo.SP_PaymentDocumentApprovals", p, commandType: CommandType.StoredProcedure);
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
