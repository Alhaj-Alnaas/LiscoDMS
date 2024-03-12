using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Flags;

namespace ACS.Core.DTOs
{
    public class MessageDTO : BaseDTO
    {
        public string SerialNumber { get; set; }
        public string SenderFullName { get; set; }
        public string SenderDiscription { get; set; }
        public string SenderId { get; set; }
        public bool IsReaded { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string OriginalBody { get; set; }
        public string OriginMessageId { get; set; }
        public bool IsOrigin { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime SendingDateTime { get; set; }
        public MessageType MessageType { get; set; }

        public virtual ICollection<MessagesCategories> MessagesCategories { get; set; }
        public virtual ICollection<Doc> Documents { get; set; }
        public virtual ICollection<Package> Packages { get; set; }

    }
}
