using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Entities
{
    public class SubApplicationUser : BaseUser
    {
        public string MainUserId { get; set; }
        public virtual ApplicationUser MainUser { get; set; }
    }
}
