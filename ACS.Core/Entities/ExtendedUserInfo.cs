using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Entities
{
   public class ExtendedUserInfo
    {
        public string EmpFileNo { get; set; }
        public string EmpName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public int RespCodeId { get; set; }
        public string EmpResponsibilitycode { get; set; }
        public string PerRespCodeNoName { get; set; }
        public int JobCatId { get; set; }
        public string JobStatus { get; set; }
        public int DesignationId { get; set; }
        public string JobtypeName { get; set; }
    }
}
