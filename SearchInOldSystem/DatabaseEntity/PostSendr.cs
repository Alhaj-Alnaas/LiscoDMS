using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SearchInOldSystem.DatabaseEntity
{
    public class PostSendr
    {
        public string LtrType { get; set; }
        public string WplacRecl { get; set; }
        public string WplacExpl { get; set; }
        public string PostTypel { get; set; }
        public string LaterInfor { get; set; }
        public string RecordNamel { get; set; }
        public string PlaceoutRec { get; set; }
        public string PlaceoutPlacer { get; set; }
        public string LtrYear { get; set; }

#nullable enable
        public double? LaterNo { get; set; }
        public DateTime? EnterDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? TrnslatDate { get; set; }
        public string? WplacRecno { get; set; }
        public string? WplacExpno { get; set; }
        public double? WplacTrnno { get; set; }
        public double? PostTypeno { get; set; }
        public double? RecordNameno { get; set; }
        public DateTime? RecivDate { get; set; }
        public double? FilnoAppend { get; set; }
       // public double? FilnoEdit { get; set; }
        public DateTime? ReciveDate { get; set; }
        public double? FlageSd { get; set; }
    }
}
