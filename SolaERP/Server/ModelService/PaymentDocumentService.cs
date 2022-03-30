namespace SolaERP.Server.ModelService
{
    public class PaymentDocumentService
    {
        public async Task<IEnumerable<PaymentDocument>> GetVendorBalance(int businessUnitId, string vendorCode)
        {
            IEnumerable<PaymentDocument> result = new List<PaymentDocument>();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@BusinessUnitId", businessUnitId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@VendorCode", vendorCode, DbType.String, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocument>("dbo.SP_PaymentDocumentVendorBalance", p, commandType: CommandType.StoredProcedure);
                    if (_result.Any()) result = _result;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }

        public async Task<IEnumerable<PaymentDocument>> GetVendorDetails(int businessUnitId, string vendorCode, string currencyCode, int paymentType)
        {
            IEnumerable<PaymentDocument> result = new List<PaymentDocument>();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@BusinessUnitId", businessUnitId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@VendorCode", vendorCode, DbType.String, ParameterDirection.Input);
                    p.Add("@CurrencyCode", currencyCode, DbType.String, ParameterDirection.Input);
                    p.Add("@DocumentType", paymentType, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocument>("dbo.SP_PaymentDocumentVendorDetails", p, commandType: CommandType.StoredProcedure);
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
