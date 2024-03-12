using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MessagesCategories> MessagesCategories { get; set; }
    }
}
