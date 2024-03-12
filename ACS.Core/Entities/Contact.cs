using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
