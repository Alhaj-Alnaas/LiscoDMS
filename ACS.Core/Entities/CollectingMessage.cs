using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ACS.Core.Entities
{
  public  class CollectingMessage 
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string SenderId { get; set; }
        public string SenderDiscription { get; set; }
        public string passedBy { get; set; }
        public string RecipintDiscription { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsReaded { get; set; }
        public bool IsReplyed { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string OriginalBody { get; set; }
        public string OriginMessageId { get; set; }
        public bool IsOrigin { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime SendingDateTime { get; set; }
       public string MessageFrom { get; set; }
        public bool IsArchived { get; set; }
        
    }
}
