using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaERP.Shared.Model
{
    public class Setting : BaseModel
    {
        public int MaxFileSize { get; set; }
        public int MaxImageSize { get; set; }
        public int MaxNumberOfFiles { get; set; }
        public int BaseCurrencyId { get; set; }
        public int DefaultTheme { get; set; }
    }
}
