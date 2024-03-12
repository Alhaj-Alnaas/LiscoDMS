using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SearchInOldSystem.DatabaseEntity
{
    public partial class Employees
    {
        public string LtrNo { get; set; }
        public string EshryNo { get; set; }
        public DateTime? EnterDate { get; set; }
        public string LtrDes { get; set; }
        public double? WplacRecno { get; set; }
        public double? WplacExpno { get; set; }
        public byte[] Photo { get; set; }
        public int? LtrYear { get; set; }
        public string SltrNo { get; set; }
    }
}
