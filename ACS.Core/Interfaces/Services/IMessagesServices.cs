using ACS.Core.DTOs;
using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
    public interface IMessagesServices<T> where T : class
    {
        Task<IEnumerable<MessageForGridDTO>> GetInboxMessages(BaseUser user, List<string> ResponsibilityCodes);
        Task<IEnumerable<MessageForGridDTO>> GetOutboxMessages(BaseUser user, List<string> ResponsibilityCodes);
        Task<IEnumerable<MessageForGridDTO>> GetDraftMessages(BaseUser user);
        Task<IEnumerable<MessageForGridDTO>> GetDeletedMessages(BaseUser user, List<string> ResponsibilityCodes);
        Task<PagingList<Message>> GetInboxMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes, int pageindex);
        Task<PagingList<Message>> GetOutboxMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes, int pageindex);
        Task<PagingList<Message>> GetDraftMessagesPagingAsync(BaseUser user, int pageindex);
        Task<PagingList<Message>> GetDeletedMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes, int pageindex);
        Task<PagingList<Message>> SearchPagingAsync(string KeyWords, string UserId, string ResponsibilityCode, int DesignationId, string JobCatId, string MessageYear, string MessageSerialNo, string MessageTitle, string MessageBody, bool MessageTypeOut, bool MessageTypeIn, string MessageOrgnization, List<string> MessageCategories, int pageindex);
        Task<IEnumerable<MessageDTO>> GetMessagesByUser(string UserId, string CurrentUserId);
        Task<Message> GetMessageByIDWithDetails(Guid messageId);
        Task<MessageDTO> GetMessageByID(Guid messageId);
        Task<int> GetLastSerialNumber(string ResponsibilityCode, int DesignationId);
        Task<int> GetCommentLastSerialNumber(Guid MessageId);
        string GetSerialNumber(string ResponsibilityCode);
        Task<bool> CheckSerialNumber(string serialNumber);
        void DeleteMessageFromInbox(Message message);
        void DeleteMessageFromOutbox(Message message);
        void DeleteMessageFromDrafts(Message message);
        void DeleteMessageFromDeleted(Message message);
        void MarkMessageAsArchivedOrUnarchived(Message message, Boolean IsArchived = false);
        void NewMessage(Message message);
        void SendMessage(Message message, BaseUser user);
        void UpdateMessage(Message message);
        Task<int> GetNewMessageCount(BaseUser user, List<string> ResponsibilityCodes);
        Task<int> GetDraftMessageCount(BaseUser user);
        Task<IEnumerable<MessageDTO>> GetMessageHistory(string messageId, string CurrentUserId);
        Task<IEnumerable<MessageDTO>> GetMessageMovements(string messageId);
        Message CloneTwoMessages(Message DisMessage, Message SourceMessage);
        Message CloneTwoDrafts(Message DisDraft, Message SourceDraft);
        //Task<PagingList<Message>> FillterPagingAsync(string UserId, string MessageYear, string MessageSerialNo, string MessageTitle,string MessageBody, string MessageType, string MessageOrgnization, int pageindex);

        List<Message> OutsideOrgnizationMessages(string UserId);

        // =========== dashboard servises Interface  ==================================================
        Task<int> GetUnreplayOutboxMessagesCount(BaseUser user);
        Task<int> GetUnreplayInboxMessagesCount(BaseUser user, List<string> ResponsibilityCodes);

        Task<List<Message>> GetUnreplayOutboxMessagesPagingAsync(BaseUser user);
        Task<List<Message>> GetUnreplayInboxMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes);

        //============================================================================================

        Task<PagingList<Message>> GetInboxMessagesClassificationAsync(BaseUser user, string ResponsibilityCodes, int pageindex);
        Task<PagingList<Message>> GetOutboxMessagesClassificationAsync(BaseUser user, string ResponsibilityCodes, int pageindex);


    }
}