using ACS.Core.DTOs;
using ACS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
    public interface IPackageServices<T> where T:class
    {
        //void SavePackgesRelitedMessage(List<Package> packages, Guid MessageId);
        void MarkMessageAsReadedOrUnreaded(Package package, bool IsReaded=true);
        //void MarkMessageAsReplied(Package package);
        void MarkMessageAsIgnored(Package package, bool IsIgnored = true);
        Task<Package> GetPackegeById(Guid Id);
        Task DeleteMessagesFromInboxAsync(List<string> messagesIds);
    }
}
