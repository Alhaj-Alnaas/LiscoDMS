using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Core.Entities
{
   public class SystemUser
    {
        public Guid Id { get; set; } 
        public string FileNumber { get; set; } //EmpFileNo
        public string FullName { get; set; } 
        public string ResponsibilityCode { get; set; }//EmpResponsibilitycode
        public string Department { get; set; } // PerRespCodeNoName
        public int RespCodeId { get; set; }
        public int JobCatId { get; set; }
        public string JobStatus { get; set; }
        public int DesignationId { get; set; }
        public string JobtypeName { get; set; }
        public string Discriminator { get; set; }

    }
}
