using ACS.Core.Entities;
using ACS.Core.Flags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ACS.Core.DTOs
{
    public class MessageForGridDTO : BaseDTO
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
        public string MessageType { get; set; }
    }
}
