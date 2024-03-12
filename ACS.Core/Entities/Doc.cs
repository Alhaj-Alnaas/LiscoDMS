using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Core.Entities
{
    public class Doc : BaseEntity
    {

        [ScaffoldColumn(false)]
        public Guid MessageId { get; set; }
        public virtual Message Message { get; set; }

        [ScaffoldColumn(false)]
        public string Path { get; set; }

        [ScaffoldColumn(false)]
        public string Extention { get; set; }

        [Display(Name = "اسم الملف")]
        public string Name { get; set; }

        [Display(Name = "حجم الملف")]
        public double Size { get; set; }

        public bool IsTemp { get; set; }
    }
}

