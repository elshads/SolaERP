using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaERP.Shared.Model
{
    public class ReportDefinition : BaseModel
    {
        public ReportDefinition() : base() { }
        public ReportDefinition(ReportDefinition instance) : base(instance)
        {
            ReportId = instance.ReportId;
            ReportName = instance.ReportName;
        }

        public int ReportId { get; set; }
        public string? ReportName { get; set; }
    }
}
