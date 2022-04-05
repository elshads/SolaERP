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
                    p.Add("@CurrencyCode", paymentDocumentMain.CurrencyCode, DbType.String, ParameterDirection.Input);
                    p.Add("@Comment", paymentDocumentMain.Comment, DbType.String, ParameterDirection.Input);
                    p.Add("@AdvanceOrder", paymentDocumentMain.PaymentDocumentTypeId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@Status", paymentDocumentMain.StatusId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@PaymentDocumentTypeId", paymentDocumentMain.PaymentDocumentTypeId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@BusinessUnitId", paymentDocumentMain.BusinessUnitId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@PaymentDocumentPriorityId", paymentDocumentMain.PaymentDocumentPriorityId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@UserId", currentUserId, DbType.Int32, ParameterDirection.Input);
                    //p.Add("@ReturnId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    result.InsertedResult = await cn.ExecuteAsync("dbo.SP_PaymentDocumentMain_IUD", p, commandType: CommandType.StoredProcedure);
                    result.ReturnId = p.Get<int>("@ReturnId");
                }


                if (result.ReturnId > 0 && paymentDocumentMain.PaymentDocumentDetailList.Any())
                {
                    foreach (var item in paymentDocumentMain.PaymentDocumentDetailList)
                    {
                        using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                        {
                            var p = new DynamicParameters();
                            p.Add("@PaymentDocumentDetailId", item.PaymentDocumentDetailId, DbType.Int32, ParameterDirection.Input);
                            p.Add("@PaymentDocumentMainId", paymentDocumentMain.PaymentDocumentMainId, DbType.Int32, ParameterDirection.Input);
                            p.Add("@OrderNumber", item.PONum, DbType.String, ParameterDirection.Input);
                            p.Add("@Voucher", item.Voucher, DbType.Int32, ParameterDirection.Input);
                            p.Add("@Amount", item.Amount, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@VAT", item.VAT, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@POAmount", item.POAmount, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@PO_VAT", item.PO_VAT, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@VoucherAmount", item.VoucherAmount, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@VoucherVAT", item.VoucherVAT, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@PaidAmount", item.PaidAmount, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@PaidVAT", item.PaidVAT, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@PaymentDocumentAmount", item.PaymentDocumentAmount, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@PaymentDocumentVat", item.PaymentDocumentVAT, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@AdvanceAmount", item.AdvanceAmount, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@AdvanceVAT", item.AdvanceVAT, DbType.Decimal, ParameterDirection.Input);
                            //p.Add("@ReturnId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                            var details = await cn.ExecuteAsync("dbo.SP_PaymentDocumentDetails_IUD", p, commandType: CommandType.StoredProcedure);
                            //result.InsertedResultCount = p.Get<int>("@ReturnId");
                        }
                    }
                }


                if (result.ReturnId > 0 && paymentDocumentMain.AttachmentList.Any())
                {
                    foreach (var item in paymentDocumentMain.AttachmentList)
                    {

                    }
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
