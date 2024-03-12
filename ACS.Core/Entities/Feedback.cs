using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Entities
{
    public class Feedback : BaseEntity
    {
        public string Note { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
