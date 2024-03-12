using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace ACS.Core.Entities
{
    public class Organization : BaseEntity
    {
        public int OrgrnalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostCenter { get; set; }
        public string DelegateNo { get; set; }
        public string DelegateName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DesignationId { get; set; }
    }
}
