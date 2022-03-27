
namespace SolaERP.Shared.Model
{
    public class PaymentType : BaseModel
    {
        public int PaymentDocumentType { get; private set; }
        public string PaymentDocumentTypeName { get; private set; }

        public static IEnumerable<PaymentType> PaymentTypeList { get; private set; } = new List<PaymentType> { new PaymentType() { PaymentDocumentType=1, PaymentDocumentTypeName="Order" }, new PaymentType() { PaymentDocumentType = 2, PaymentDocumentTypeName = "Advance" } };
    }
}
