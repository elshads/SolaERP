namespace SolaERP.Server.ModelService
{
    public class PaymentDocumentService
    {
        public async Task<IEnumerable<PaymentDocumentMain>> GetAll(int userId, int businessUnitId, int tabindex)
        {
            IEnumerable<PaymentDocumentMain> result = new List<PaymentDocumentMain>();
            try
            {
                var procedure = "";
                switch (tabindex)
                {
                    case 0:
                        procedure = "dbo.SP_PaymentDocumentWFA";
                        break;
                    case 1:
                        procedure = "dbo.SP_PaymentDocumentDrafts";
                        break;
                    case 2:
                        procedure = "dbo.SP_PaymentDocumentAll";
                        break;
                    case 3:
                        procedure = "dbo.SP_PaymentDocumentApproved";
                        break;
                    case 4:
                        procedure = "dbo.SP_PaymentDocumentBank";
                        break;
                    default:
                        procedure = "dbo.SP_PaymentDocumentAll";
                        break;
                }

                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);
                    p.Add("@BusinessUnitId", businessUnitId, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocumentMain>(procedure, p, commandType: CommandType.StoredProcedure);
                    if (_result.Any()) result = _result;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }

        public async Task<PaymentDocumentMain> GetById(int modelId)
        {
            PaymentDocumentMain result = new();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@PaymentDocumentMainId", modelId, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocumentMain>("dbo.SP_PaymentDocumentMainLoad", p, commandType: CommandType.StoredProcedure);
                    if (_result.Any()) result = _result.FirstOrDefault();
                }
                if (result.PaymentDocumentMainId > 0)
                {
                    using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                    {
                        var p = new DynamicParameters();
                        p.Add("@PaymentDocumentMainId", modelId, DbType.Int32, ParameterDirection.Input);
                        var _result = await cn.QueryAsync<PaymentDocumentDetail>("dbo.SP_PaymentDocumentDetailsLoad", p, commandType: CommandType.StoredProcedure);
                        if (_result.Any()) result.PaymentDocumentDetailList = _result.ToList();
                    }

                    using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                    {
                        var p = new DynamicParameters();
                        p.Add("@SourceId", modelId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@SourceType", "PYMDC", DbType.String, ParameterDirection.Input);
                        p.Add("@Reference", null, DbType.String, ParameterDirection.Input);
                        var _result = await cn.QueryAsync<Attachment>("dbo.SP_AttachmentList_Load", p, commandType: CommandType.StoredProcedure);
                        if (_result.Any()) result.AttachmentList = _result.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                result.ReturnMessage = e.Message;
            }
            return result;
        }

        public async Task<PaymentDocumentPostMain> GetPost(int id)
        {
            PaymentDocumentPostMain result = new();
            try
            {
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("@PaymentDocumentMainId", id, DbType.Int32, ParameterDirection.Input);
                    var _result = await cn.QueryAsync<PaymentDocumentPostMain>("dbo.SP_PaymentDocumentMainLoad", p, commandType: CommandType.StoredProcedure);
                    if (_result.Any()) result = _result.FirstOrDefault();
                }
                if (result.PaymentDocumentMainId > 0)
                {
                    using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                    {
                        var p = new DynamicParameters();
                        p.Add("@PaymentDocumentMainId", id, DbType.Int32, ParameterDirection.Input);
                        var _result = await cn.QueryAsync<PaymentDocumentPostDetail>("dbo.SP_PaymentDocumentDetailsLoad", p, commandType: CommandType.StoredProcedure);
                        if (_result.Any()) result.PaymentDocumentPostDetailList = _result.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                result.ReturnMessage = e.Message;
            }
            return result;
        }

        public async Task<SqlResult> PostDocument(PaymentDocumentPostMain model, int userId)
        {
            SqlResult result = new();
            try
            {
                foreach (var item in model.PaymentDocumentPostDetailList)
                {
                    using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                    {
                        var p = new DynamicParameters();
                        p.Add("@PaymentDocumentDetailId", item.PaymentDocumentDetailId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@Date", model.PaymentDate, DbType.DateTime, ParameterDirection.Input);
                        p.Add("@BankCode", model.BankCode, DbType.String, ParameterDirection.Input);
                        p.Add("@BankAmount", item.BankAmount, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@VendorAmount", item.VendorAmount, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@BankRate", item.BankRate, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@VendorRate", item.VendorRate, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@VAT", item.VAT, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@VATBankAmount", item.VATBankAmount, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@VATBank", model.VATBankCode, DbType.String, ParameterDirection.Input);
                        p.Add("@BankCharge", model.BankCharge, DbType.Decimal, ParameterDirection.Input);
                        p.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ExpenseCode", model.ExpenseCode, DbType.String, ParameterDirection.Input);
                        p.Add("@GroupProject", model.GroupProject, DbType.String, ParameterDirection.Input);
                        p.Add("@Project", model.Project, DbType.String, ParameterDirection.Input);
                        await cn.QueryAsync("dbo.SP_PaymentDocumentPost", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception e)
            {
                result.InsertedResultMessage = e.Message;
            }
            return result;
        }


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
                    p.Add("@NewPaymentDocumentMainId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    result.InsertedResult = await cn.ExecuteAsync("dbo.SP_PaymentDocumentMain_IUD", p, commandType: CommandType.StoredProcedure);
                    result.ReturnId = p.Get<int>("@NewPaymentDocumentMainId");
                }


                if (result.ReturnId > 0 && paymentDocumentMain.PaymentDocumentDetailList.Any())
                {
                    foreach (var item in paymentDocumentMain.PaymentDocumentDetailList)
                    {
                        using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                        {
                            var p = new DynamicParameters();
                            p.Add("@PaymentDocumentDetailId", item.PaymentDocumentDetailId, DbType.Int32, ParameterDirection.Input);
                            p.Add("@PaymentDocumentMainId", (paymentDocumentMain.PaymentDocumentMainId > 0 ? paymentDocumentMain.PaymentDocumentMainId : result.ReturnId), DbType.Int32, ParameterDirection.Input);
                            p.Add("@OrderNumber", item.PONum, DbType.String, ParameterDirection.Input);
                            p.Add("@Voucher", item.Voucher, DbType.Int32, ParameterDirection.Input);
                            p.Add("@Amount", item.AmountToPay, DbType.Decimal, ParameterDirection.Input);
                            p.Add("@VAT", item.VATToPay, DbType.Decimal, ParameterDirection.Input);
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

                            await cn.ExecuteAsync("dbo.SP_PaymentDocumentDetails_IUD", p, commandType: CommandType.StoredProcedure);
                        }
                    }
                }


                if (result.ReturnId > 0 && paymentDocumentMain.AttachmentList.Any())
                {
                    foreach (var item in paymentDocumentMain.AttachmentList)
                    {
                        using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                        {
                            var p = new DynamicParameters();
                            p.Add("@AttachmentId", item.AttachmentId, DbType.Int32, ParameterDirection.Input);
                            p.Add("@FileName", item.FileName, DbType.String, ParameterDirection.Input);
                            p.Add("@FileData", item.FileData, DbType.Binary, ParameterDirection.Input);
                            p.Add("@SourceId", (paymentDocumentMain.PaymentDocumentMainId > 0 ? paymentDocumentMain.PaymentDocumentMainId : result.ReturnId), DbType.Int32, ParameterDirection.Input);
                            p.Add("@SourceType", "PYMDC", DbType.String, ParameterDirection.Input);
                            p.Add("@Reference", item.Reference, DbType.String, ParameterDirection.Input);
                            p.Add("@ExtensionType", item.ExtensionType, DbType.String, ParameterDirection.Input);
                            p.Add("@AttachmentTypeId", item.AttachmentTypeId, DbType.Int32, ParameterDirection.Input);
                            p.Add("@AttachmentSubTypeId", item.AttachmentSubTypeId, DbType.Int32, ParameterDirection.Input);

                            await cn.ExecuteAsync("dbo.SP_Attachments_IUD", p, commandType: CommandType.StoredProcedure);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.InsertedResultMessage = e.Message;
            }
            return result;
        }

        public async Task<SqlResult> Approve(IEnumerable<ApproveData> approveDataList, int currentUserId)
        {
            SqlResult result = new();
            try
            {
                foreach (var item in approveDataList)
                {
                    using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                    {
                        var p = new DynamicParameters();
                        p.Add("@PaymentDocumentMainId", item.ModelId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@ApproveStatusId", item.ApproveStatusId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@Comment", item.Comment, DbType.String, ParameterDirection.Input);
                        p.Add("@Sequence", item.Sequence, DbType.Int32, ParameterDirection.Input);
                        p.Add("@UserId", currentUserId, DbType.Int32, ParameterDirection.Input);

                        result.InsertedResult = await cn.ExecuteAsync("dbo.SP_PaymentDocumentsApprove", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception e)
            {
                result.InsertedResultMessage = e.Message;
            }
            return result;
        }

        public async Task<SqlResult> ChangeApproveStatus(IEnumerable<ApproveData> statusDataList, int currentUserId)
        {
            SqlResult result = new();
            try
            {
                foreach (var item in statusDataList)
                {
                    using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                    {
                        var p = new DynamicParameters();
                        p.Add("@PaymentDocumentMainId", item.ModelId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@Status", item.ApproveStatusId, DbType.Int32, ParameterDirection.Input);
                        p.Add("@UserId", currentUserId, DbType.Int32, ParameterDirection.Input);

                        result.InsertedResult = await cn.ExecuteAsync("dbo.SP_PaymentDocumentsChangeStatus", p, commandType: CommandType.StoredProcedure);
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
