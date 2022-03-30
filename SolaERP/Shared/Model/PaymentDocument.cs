﻿
namespace SolaERP.Shared.Model
{
    public class PaymentDocument : BaseModel
    {
        public string BusinessUnitCode { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public int PaymentDocumentType { get; set; }
        public string PaymentDocumentTypeName { get; set; }
        public string PONum { get; set; }
        public string Voucher { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public decimal POAmount { get; set; }
        public decimal PO_VAT { get; set; }
        public decimal VoucherAmount { get; set; }
        public decimal VoucherVAT { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal AdvanceVAT { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PaidVAT { get; set; }
        public decimal PaymentDocumentAmount { get; set; }
        public decimal PaymentDocumentVAT { get; set; }
        public decimal AmountToPay { get; set; }
        public decimal VATToPay { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal RemainingVAT { get; set; }
        public decimal TotalToPay { get; set; }
        public bool IsVAT { get; set; }
    }
}
