using ACS.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACS.Core.DTOs
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
