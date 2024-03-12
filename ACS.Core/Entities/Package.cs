using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Core.Entities
{
    public class Package : BaseEntity
    {
        public Guid MessageId { get; set; }
        public Message Message { get; set; }
        public string RecipintId { get; set; }
        public virtual ApplicationUser Recipint { get; set; }
        public bool IsReaded { get; set; } = false;
        public bool IsReplyed { get; set; } = false;
        public bool IsIgnore { get; set; } = false;
        public string RecipintDiscription { get; set; }
        public int DesignationId { get; set; }
        public int DaysToReplay { get; set; }
        public bool IsCC { get; set; } = false;
        public bool IsArchived { get; set; }
    }
}
