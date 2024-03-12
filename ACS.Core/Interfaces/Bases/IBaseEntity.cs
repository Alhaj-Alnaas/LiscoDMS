
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedOn { get; set; }
        string CreatedById { get; set; }
        BaseUser CreatedBy { get; set; }
        string DeletedById { get; set; }
        bool IsDeleted { get; set; }
        BaseUser DeletedBy { get; set; }
        DateTime? DeletedOn { get; set; }
        string LastUpdatedById { get; set; }
        BaseUser LastUpdatedBy { get; set; }
        DateTime? LastUpdatedOn { get; set; }
    }
}
