using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.Core.Entities.Bases
{
    public class BaseEntity 
    {
        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "الجهة")]
        [Column(TypeName = "varchar(6)")]
        public string ResponsibilityCode { get; set; }

        [Display(Name = "تاريخ الإنشاء")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedById { get; set; }
        public BaseUser CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; } = false;

        [DefaultValue(false)]
        public string DeletedById { get; set; }
        public BaseUser DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        [DefaultValue(false)]
        public string LastUpdatedById { get; set; }
        public BaseUser LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
