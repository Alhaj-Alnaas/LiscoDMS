using ACS.Core.Entities.Bases;
using ACS.Core.Flags;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ACS.Core.Entities
{
    public class Message : BaseEntity
    {
        public string SerialNumber { get; set; }

        //[Required(ErrorMessage = "أدخل عنوان الرسالة...من فضلك")]
        [Display(Name = "عنوان الرسالة")]
        public string Title { get; set; }

        [Display(Name = "نص الرسالة")]
        public string Body { get; set; }

        public string OriginalBody { get; set; }

        public bool Sent { get; set; }

        [ScaffoldColumn(false)]
        public bool IsOrigin { get; set; }

        [ScaffoldColumn(false)]
        public bool NotifyMe { get; set; }

        [ScaffoldColumn(false)]
        public string OriginMessageId { get; set; }

        public string SenderDiscription { get; set; }
        public virtual BaseUser Sender { get; set; }
        public string SenderId { get; set; }
        //public virtual Package Package { get; set; }

        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }

        [Display(Name = "تاريخ الإرسال")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime SendingDateTime { get; set; }
        public MessagePrivacy MessagePrivacy { get; set; }
        public MessageType MessageType { get; set; }
        public bool IsForeign { get; set; } = false;
        public int DesignationId { get; set; }
        public virtual ICollection<MessagesCategories> MessagesCategories { get; set; }
        public virtual ICollection<Doc> Documents { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
