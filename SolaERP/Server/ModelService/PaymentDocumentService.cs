namespace SolaERP.Server.ModelService
{
    public class PaymentDocumentService
    {
        public async Task<IEnumerable<PaymentDocumentDetail>> GetVendorBalance(int businessUnitId, string vendorCode)
        {
            IEnumerable<PaymentDocumentDetail> result = new List<PaymentDocumentDetail>();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@BusinessUnitId", businessUnitId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@VendorCode", vendorCode, DbType.String, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocumentDetail>("dbo.SP_PaymentDocumentVendorBalance", p, commandType: CommandType.StoredProcedure);
                    if (_result.Any()) result = _result;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }

        public async Task<IEnumerable<PaymentDocumentDetail>> GetVendorDetails(int businessUnitId, string vendorCode, string currencyCode, int paymentType)
        {
            IEnumerable<PaymentDocumentDetail> result = new List<PaymentDocumentDetail>();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@BusinessUnitId", businessUnitId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@VendorCode", vendorCode, DbType.String, ParameterDirection.Input);
                    p.Add("@CurrencyCode", currencyCode, DbType.String, ParameterDirection.Input);
                    p.Add("@DocumentType", paymentType, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocumentDetail>("dbo.SP_PaymentDocumentVendorDetails", p, commandType: CommandType.StoredProcedure);
                    if (_result.Any()) result = _result;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }

        public async Task<SqlResult> Save(PaymentDocumentMain paymentDocumentMain, int currentUserId)
        {
            SqlResult result = new();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@PaymentDocumentMainId", paymentDocumentMain.PaymentDocumentMainId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@Reference", paymentDocumentMain.Reference, DbType.String, ParameterDirection.Input);
                    p.Add("@VendorCode", paymentDocumentMain.VendorCode, DbType.String, ParameterDirection.Input);
                    p.Add("@CurrencyCode", paymentDocumentMain.CurrencyCode, DbType.Int32, ParameterDirection.Input);
                    p.Add("@Comment", paymentDocumentMain.Comment, DbType.Int32, ParameterDirection.Input);
                    p.Add("@AdvanceOrder", paymentDocumentMain.PaymentDocumentTypeId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@Status", paymentDocumentMain.StatusId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@PaymentDocumentTypeId", paymentDocumentMain.PaymentDocumentTypeId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@BusinessUnitId", paymentDocumentMain.BusinessUnitId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@PaymentDocumentPriorityId", paymentDocumentMain.PaymentDocumentPriorityId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@UserId", currentUserId, DbType.Int32, ParameterDirection.Input);
                    //p.Add("@NewId", paymentType, DbType.Int32, ParameterDirection.Output);
                    result.InsertedResult = await cn.ExecuteAsync("dbo.SP_PaymentDocumentMain_IUD", p, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                result.InsertedResultMessage = e.Message;
            }
            return result;
        }
    }
}
