using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaERP.Shared.Model
{
    public class AttachmentType : BaseModel
    {
        public int AttachmentTypeId { get; set; }
        public string AttachmentTypeName { get; set; }
        public bool HasItems { get; set; }

        public static IEnumerable<AttachmentType> AttachmentTypeList { get; private set; } = new List<AttachmentType> {
            new AttachmentType() { AttachmentTypeId=1, AttachmentTypeName="Contract", HasItems=false },
            new AttachmentType() { AttachmentTypeId=2, AttachmentTypeName="E-Invoice", HasItems=false },
            new AttachmentType() { AttachmentTypeId=3, AttachmentTypeName="Delivery Notes", HasItems=false },
            new AttachmentType() { AttachmentTypeId=4, AttachmentTypeName="Vendor Invoice", HasItems=true },
            new AttachmentType() { AttachmentTypeId=5, AttachmentTypeName="Final Payment", HasItems=false },
            new AttachmentType() { AttachmentTypeId=6, AttachmentTypeName="Others", HasItems=false },
        };
    }
}
