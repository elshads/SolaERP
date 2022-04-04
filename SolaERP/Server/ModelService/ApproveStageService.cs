namespace SolaERP.Server.ModelService
{
    public class ApproveStageService
    {
        public async Task<IEnumerable<ApproveStage>> GetAllAsync(int paymentDocumentMainId)
        {
            IEnumerable<ApproveStage> result = new List<ApproveStage>();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
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
