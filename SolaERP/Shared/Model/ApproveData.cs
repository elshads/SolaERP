﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaERP.Shared.Model
{
    public class ApproveData : BaseModel
    {
        public int ModelId { get; set; }
        public int UserId { get; set; }
        public int ApproveStatusId { get; set; }
        public string? Comment { get; set; }
        public int Sequence { get; set; }
    }
}
