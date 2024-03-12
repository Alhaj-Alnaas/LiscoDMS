using ACS.Core.Entities.Bases;
using System;

namespace ACS.Core.Entities
{
    public class Notification :BaseEntity
    {
        public string MessageId { get; set; }
        public string MessageType { get; set; }
    }
}
