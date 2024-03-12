using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACS.Core.DTOs
{
        public class MessageForListViewDTO : BaseDTO
    {
        public string SerialNumber { get; set; }
        public string SenderFullName { get; set; }
        public string SenderDiscription { get; set; }
        public string SenderId { get; set; }

        public string MainSenderFullName { get; set; }
        public string MainSenderDiscription { get; set; }
        public string MainSenderId { get; set; }

        public string RecipientFullName { get; set; }
        public string RecipientDiscription { get; set; }
        public string RecipientId { get; set; }

        public bool IsReaded { get; set; }
        public bool IsDeleted { get; set; }
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
