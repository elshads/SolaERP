using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaERP.Shared.Model
{
    public class PaymentDocumentDestination : BaseModel
    {
        public int PaymentDocumentDestinationId { get; private set; }
        public string PaymentDocumentDestinationName { get; private set; }

        public IEnumerable<int> AttachmentTypeIdList { get; set; }

        public static IEnumerable<PaymentDocumentDestination> PaymentDocumentDestinationList { get; private set; } = new List<PaymentDocumentDestination> {
            new PaymentDocumentDestination() { PaymentDocumentDestinationId = 1, PaymentDocumentDestinationName = "Advance", AttachmentTypeIdList = new List<int> { 1, 2, 4, 6 } },
            new PaymentDocumentDestination() { PaymentDocumentDestinationId = 2, PaymentDocumentDestinationName = "Internal PO", AttachmentTypeIdList = new List<int> { 1, 2, 3, 4, 5, 6 } },
            new PaymentDocumentDestination() { PaymentDocumentDestinationId = 3, PaymentDocumentDestinationName = "Production PO", AttachmentTypeIdList = new List<int> { 1, 2, 3, 4, 5, 6 } },
            new PaymentDocumentDestination() { PaymentDocumentDestinationId = 4, PaymentDocumentDestinationName = "Service", AttachmentTypeIdList = new List<int> { 1, 2, 3, 4, 5, 6 } },
            new PaymentDocumentDestination() { PaymentDocumentDestinationId = 5, PaymentDocumentDestinationName = "Landed Cost", AttachmentTypeIdList = new List<int> { 1, 2, 4, 5, 6 } },
        };
    }
}
