using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACS.Core.Entities
{
    public class MessagesCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid MessageId { get; set; }
        public Message Message { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
