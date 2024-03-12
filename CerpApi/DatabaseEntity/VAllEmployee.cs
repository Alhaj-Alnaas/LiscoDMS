using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CerpApi.DatabaseEntity
{
    public partial class VAllEmployee
    {
        [Key]
        public string EmpFileNo { get; set; }
        public string EmpName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string RespCodeId { get; set; }
        public string EmpResponsibilitycode { get; set; }
        public string PerRespCodeNoName { get; set; }
        public int JobCatId { get; set; }
        public string JobStatus { get; set; }
        public int DesignationId { get; set; }
        public string JobtypeName { get; set; }

    }
}
