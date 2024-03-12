using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Core.Entities.Bases
{
    public class BaseUser : IdentityUser
    {
        [MaxLength(6)]
        [Column(TypeName = "varchar(6)")]
        [Required(ErrorMessage = "أدخل الرقم الوظيفي...من فضلك")]
        [Display(Name = "الرقم الوظيفي")]
        public string FileNumber { get; set; } //EmpFileNo

        [ScaffoldColumn(false)]
        [Display(Name = "الجهة")]
        [Column(TypeName = "varchar(6)")]
        public string ResponsibilityCode { get; set; }//EmpResponsibilitycode

        [Display(Name = "الاسم")]
        public string FullName { get; set; } //EmpName

        [Display(Name = "التقسيم الإداري")] 
        public string Department { get; set; } // PerRespCodeNoName
        public int RespCodeId { get; set; }
        public int JobCatId { get; set; }
        public string JobStatus { get; set; }
        public int DesignationId { get; set; }
        public string JobtypeName { get; set; }
        public string PhoneConfirmationCode { get; set; }
        public string ArchiveUserPassword { get; set; }
        public Boolean IsArchiveUser { get; set; } = false;
        public Boolean WorkWithLastVersion { get; set; } = true;
        public string Discriminator { get; set; }

    }
}
