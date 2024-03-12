using ACS.Core.DTOs;
using ACS.Core.Entities;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ACS.Core.Entities.Bases;
using ReflectionIT.Mvc.Paging;
using System.Linq.Expressions;

namespace ACS.Services
{
    public class MessagesServices<T> : IMessagesServices<T> where T : Message
    {
        private readonly IUnitOfWork<Message> _unitOfWork;
        private readonly IMapper _mapper;

        public MessagesServices(
            IUnitOfWork<Message> unitOfWork
            , IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> GetCommentLastSerialNumber(Guid MessageId)
        {
            return (await _unitOfWork.Entity.GetAllAsync(m => m.OriginMessageId == MessageId.ToString())).Count();
            
        }
        public async Task<IEnumerable<MessageForGridDTO>> GetInboxMessages(BaseUser user, List<string> ResponsibilityCodes)
        {
            IEnumerable<Message> messages;
            if (user.JobCatId == 1)
            {
                messages = (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
                x => x.IsDeleted == false &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId) ||
                (x.RecipintId == user.Id && x.ResponsibilityCode == null))
                )
            , x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Sender")).GroupBy(item => item.OriginMessageId).Select(grp => grp.OrderByDescending(f => f.SendingDateTime).FirstOrDefault());

                foreach (var message in messages)
                {
                    var package = message.Packages.FirstOrDefault(
                        h => h.IsDeleted == false &&
                (ResponsibilityCodes.Contains(h.ResponsibilityCode) ||
                (h.ResponsibilityCode == user.ResponsibilityCode && h.DesignationId == user.DesignationId) ||
                (h.RecipintId == user.Id && h.ResponsibilityCode == null))
                        );
                    message.Packages.Clear();
                    message.Packages.Add(package);
                    //if (message.SerialNumber == null && message.IsOrigin == false)
                    //{
                    //    var sn= (await _unitOfWork.Entity.FindAsync(x => x.Id == Guid.Parse(message.OriginMessageId) && x.SerialNumber != null)).SerialNumber.ToString();
                        
                    //    if (sn != null)
                    //    { message.SerialNumber = sn;
                    //    }
                           
                    //}
                }
            }
            else
            {
                messages = (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(

                x => x.IsDeleted == false &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.RecipintId == user.Id)))
            , x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Sender")).GroupBy(item => item.OriginMessageId).Select(grp => grp.OrderByDescending(f => f.SendingDateTime).FirstOrDefault());

                foreach (var message in messages)
                {
                    var package = message.Packages.FirstOrDefault(
                        h => h.IsDeleted == false &&
                (ResponsibilityCodes.Contains(h.ResponsibilityCode) ||
                (h.RecipintId == user.Id))
                        );
                    message.Packages.Clear();
                    message.Packages.Add(package);
                    if (message.SerialNumber == null && message.IsOrigin == false)
                    {
                        message.SerialNumber = (await _unitOfWork.Entity.FindAsync(x => x.Id == Guid.Parse(message.OriginMessageId))).SerialNumber;
                    }
                }
            }
            return _mapper.Map<IEnumerable<MessageForGridDTO>>(messages);
        }

        public async Task<IEnumerable<MessageForGridDTO>> GetOutboxMessages(BaseUser user, List<string> ResponsibilityCodes)
        {
            IEnumerable<Message> messages;
            if (user.JobCatId == 1)
            {
                messages = await _unitOfWork.Entity.GetAllAsync(x => ((x.Sender.Id == user.Id && x.ResponsibilityCode == null) ||
                ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId)) &&
                x.IsDeleted == false && x.Sent == true, x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Sender");
            }
            else
            {
                messages = await _unitOfWork.Entity.GetAllAsync(x => (x.Sender.Id == user.Id || ResponsibilityCodes.Contains(x.ResponsibilityCode)) && x.IsDeleted == false && x.Sent == true, x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Sender");
            }

            foreach (var message in messages)
            {
                message.SenderDiscription = "";
                foreach (var package in message.Packages)
                {
                    message.SenderDiscription += package.RecipintDiscription + "، ";
                }
            }

            return _mapper.Map<IEnumerable<MessageForGridDTO>>(messages);
        }

        public async Task<IEnumerable<MessageForGridDTO>> GetDraftMessages(BaseUser user)
        {
            IEnumerable<Message> messages;
            if (user.JobCatId == 1)
            {
                messages = await _unitOfWork.Entity.GetAllAsync(x => (x.CreatedById == user.Id || x.ResponsibilityCode == user.ResponsibilityCode) && x.Sent == false, t => t.OrderByDescending(r => r.CreatedOn), "CreatedBy");
            }
            else
            {
                messages = await _unitOfWork.Entity.GetAllAsync(x => x.CreatedById == user.Id && x.Sent == false, t => t.OrderByDescending(r => r.CreatedOn), "CreatedBy");
            }

            foreach (var message in messages)
            {
                message.SenderDiscription = message.CreatedBy.FullName;
            }

            return _mapper.Map<IEnumerable<MessageForGridDTO>>(messages);
        }

        public async Task<IEnumerable<MessageForGridDTO>> GetDeletedMessages(BaseUser user, List<string> ResponsibilityCodes)
        {
            IEnumerable<Message> messages;
            if (user.JobCatId == 1)
            {
                messages = await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && x.Packages.Any(x => x.IsDeleted == true &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.Recipint.Id == user.Id && x.ResponsibilityCode == null) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId))), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Packages.DeletedBy");
            }
            else
            {
                messages = await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && x.Packages.Any(x => x.IsDeleted == true && (x.Recipint.Id == user.Id || ResponsibilityCodes.Contains(x.ResponsibilityCode))), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Packages.DeletedBy");
            }

            //foreach (var message in messages)
            //{
            //    message.SenderDiscription = message.DeletedBy.FullName;
            //}

            return _mapper.Map<IEnumerable<MessageForGridDTO>>(messages);
        }

        public async Task<PagingList<Message>> GetInboxMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes, int pageindex)
        {
            if (user.JobCatId == 1)
            {
                var messages = await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
                x => x.IsDeleted == false &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId) ||
                (x.RecipintId == user.Id && x.ResponsibilityCode == null)))
            , x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Documents,Sender");
                return PagingList.Create(messages, 30, pageindex);
            }
            else
            {
                var messages = await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
                x => x.IsDeleted == false &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.RecipintId == user.Id && x.ResponsibilityCode == null)))
            , x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Documents,Sender");
                return PagingList.Create(messages, 30, pageindex);
            }
        }

        public async Task<PagingList<Message>> GetOutboxMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes, int pageindex)
        {
            if (user.JobCatId == 1)
            {
                return PagingList.Create((await _unitOfWork.Entity.GetAllAsync(x => (x.Sender.Id == user.Id ||
                ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId)) &&
                x.IsDeleted == false && x.Sent == true, null, "Packages,Documents,Sender")).OrderByDescending(o => o.SendingDateTime), 30, pageindex);
            }
            else
            {
                return PagingList.Create((await _unitOfWork.Entity.GetAllAsync(x => (x.Sender.Id == user.Id || ResponsibilityCodes.Contains(x.ResponsibilityCode)) && x.IsDeleted == false && x.Sent == true, null, "Packages,Documents,Sender")).OrderByDescending(o => o.SendingDateTime), 30, pageindex);
            }
        }

        public async Task<PagingList<Message>> GetDraftMessagesPagingAsync(BaseUser user, int pageindex)
        {
            if (user.JobCatId == 1)
            {
                return PagingList.Create(await _unitOfWork.Entity.GetAllAsync(x => (x.CreatedById == user.Id || x.ResponsibilityCode == user.ResponsibilityCode) && x.Sent == false, t => t.OrderByDescending(r => r.CreatedOn), "Packages,Documents,Sender,CreatedBy"), 30, pageindex);
            }
            else
            {
                return PagingList.Create(await _unitOfWork.Entity.GetAllAsync(x => x.CreatedById == user.Id && x.Sent == false, t => t.OrderByDescending(r => r.CreatedOn), "Packages,Documents,Sender,CreatedBy"), 30, pageindex);
            }
        }
        public async Task<PagingList<Message>> GetDeletedMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes, int pageindex)
        {
            if (user.JobCatId == 1)
            {
                return PagingList.Create(await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && x.Packages.Any(x => x.IsDeleted == true &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.Recipint.Id == user.Id && x.ResponsibilityCode == null) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId))), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender,Packages.Recipint"), 30, pageindex);
            }
            else
            {
                return PagingList.Create(await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && x.Packages.Any(x => x.IsDeleted == true && (x.Recipint.Id == user.Id || ResponsibilityCodes.Contains(x.ResponsibilityCode))), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender,Packages.Recipint"), 30, pageindex);
            }
        }
        public async Task<PagingList<Message>> SearchPagingAsync(string KeyWords, string UserId, string ResponsibilityCode, int DesignationId, string JobCatId, string MessageYear, string MessageSerialNo, string MessageTitle, string MessageBody, bool MessageTypeOut, bool MessageTypeIn, string MessageOrgnization, List<string> MessageCategories, int pageindex)
        {
            Expression<Func<Message, bool>> filter;
            if (DateTime.TryParse(KeyWords, out DateTime dDate))
            {
                String.Format("{0:yyyy-MM-dd}", dDate);
            }
            if (JobCatId == "1")
            {
                filter =
                x => x.IsDeleted == false
                //&& x.IsOrigin == true
                && (x.Sender.Id == UserId || (x.ResponsibilityCode == ResponsibilityCode && x.DesignationId == DesignationId) ||
                x.Packages.Any(p => p.Recipint.Id == UserId || (p.ResponsibilityCode == ResponsibilityCode && p.DesignationId == DesignationId)))
                &&
                (x.SerialNumber.Contains(KeyWords)
                || x.Title.Contains(KeyWords)
                || x.OriginalBody.Contains(KeyWords)
                || x.Body.Contains(KeyWords)
                || x.SenderDiscription.Contains(KeyWords)
                || x.SendingDateTime.Date == dDate.Date
                );
            }
            else
            {
                filter =
                x => x.IsDeleted == false
                //&& x.IsOrigin == true
                && (x.Sender.Id == UserId || x.Packages.Any(p => p.Recipint.Id == UserId))
                &&
                (x.SerialNumber.Contains(KeyWords)
                || x.Title.Contains(KeyWords)
                || x.OriginalBody.Contains(KeyWords)
                || x.Body.Contains(KeyWords)
                || x.SenderDiscription.Contains(KeyWords)
                || x.SendingDateTime.Date == dDate.Date
                );
            }

            var messages = await _unitOfWork.Entity.GetAllAsync(filter
                , x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender,MessagesCategories");

            if (MessageYear != null)
                messages = messages.Where(x => x.SendingDateTime.Year.ToString().Contains(MessageYear));

            if (MessageSerialNo != null)
                messages = messages.Where(x => x.SerialNumber.Contains(MessageSerialNo));

            if (MessageTitle != null)
                messages = messages.Where(x => x.Title.Contains(MessageTitle));

            if (MessageBody != null)
                messages = messages.Where(x => x.OriginalBody.Contains(MessageBody));

            if (MessageOrgnization != null)
                messages = messages.Where(x => x.SenderDiscription.Contains(MessageOrgnization) || x.Packages.Any(p => p.RecipintDiscription.Contains(MessageOrgnization)));

            if (MessageTypeOut == true && MessageTypeIn == true)
                messages = messages.Where(x => x.Sender.Id == UserId || x.Packages.Any(p => p.RecipintId == UserId));
            else if (MessageTypeOut == true && MessageTypeIn == false)
                messages = messages.Where(x => x.Sender.Id == UserId);
            else if (MessageTypeOut == false && MessageTypeIn == true)
                messages = messages.Where(x => x.Packages.Any(p => p.RecipintId == UserId));
            else if (MessageTypeOut == false && MessageTypeIn == false)
                messages = messages.Where(x => x.Sender.Id != UserId && x.Packages.Any(p => p.RecipintId != UserId));

            if (MessageCategories.Count > 0)
            {
                messages = messages.Where(x => x.MessagesCategories.Any(t => MessageCategories.Contains(t.CategoryId.ToString())));
            }

            return PagingList.Create(messages, 30, pageindex);
        }

        public async Task<IEnumerable<MessageDTO>> GetMessagesByUser(string UserId, string CurrentUserId)
        {
            var messages = (await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && x.Sender.Id == UserId, x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender,MessagesCategories")).AsQueryable().SelectMany(p => p.Packages).Where(x => x.IsDeleted == false && x.Recipint.Id == CurrentUserId).AsEnumerable().Select(r => r.Message);

            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
        public async Task<MessageDTO> GetMessageByID(Guid Id)
        {
            return _mapper.Map<MessageDTO>(await _unitOfWork.Entity.FindAsync(m => m.Id == Id, "Packages,Documents,Sender,MessagesCategories"));
        }
        public async Task<Message> GetMessageByIDWithDetails(Guid Id)
        {
            return await _unitOfWork.Entity.FindAsync(m => m.Id == Id, "Packages,Documents,Sender,MessagesCategories");
        }
        public void DeleteMessageFromInbox(Message message)
        {
            _unitOfWork.Entity.Delete(message);
            _unitOfWork.Save();
        }
        public void DeleteMessageFromOutbox(Message message)
        {
            _unitOfWork.Entity.Delete(message);
            _unitOfWork.Save();
        }
        public void DeleteMessageFromDrafts(Message message)
        {
            _unitOfWork.Entity.PermanentDelete(message);
            _unitOfWork.Save();
        }
        public void DeleteMessageFromDeleted(Message message)
        {
            _unitOfWork.Entity.PermanentDelete(message);
            _unitOfWork.Save();
        }
        public void UpdateMessage(Message message)
        {
            _unitOfWork.Entity.Update(message);
            _unitOfWork.Save();
        }
        public async Task<int> GetLastSerialNumber(string ResponsibilityCode, int DesignationId)
        {
            //return  DateTime.Now.ToString("yy") + "-" + ResponsibilityCode + "-" +((await _unitOfWork.Entity.GetAllAsync(m => m.ResponsibilityCode == ResponsibilityCode && m.DesignationId == DesignationId && m.Sent == true && m.SerialNumber != null && m.CreatedOn.Year == DateTime.Now.Year)).Count() + 1).ToString("0000");

            var SerailNumbers = ((await _unitOfWork.Entity.GetAllAsync(m => m.ResponsibilityCode == ResponsibilityCode && m.DesignationId == DesignationId && m.Sent == true && m.SerialNumber != null && m.IsForeign== false && m.SerialNumber.Length==13  && m.CreatedOn.Year == DateTime.Now.Year)).OrderByDescending(x => x.CreatedOn).Select(x => x.SerialNumber.Substring(9, 4)).ToList());
        
            int temp;
            int SN = 0;
            if (SerailNumbers.Count > 0)
            {
                SN = SerailNumbers.Select(n => int.TryParse(n, out temp) ? temp : 0).Max() ;

            }
            return SN+1;
        }
        public string GetSerialNumber(string ResponsibilityCode)
        {
            return DateTime.Now.ToString("yy") + "-" + ResponsibilityCode;
        }
        public async Task<bool> CheckSerialNumber(string serialNumber)
        {
            var result = (await _unitOfWork.Entity.GetAllAsync(m => m.SerialNumber == serialNumber)).ToList();
            return result.Count > 0;
        }
        public void MarkMessageAsArchivedOrUnarchived(Message message, bool IsArchived = false)
        {
            message.IsArchived = IsArchived;
            _unitOfWork.Entity.Update(message);
            _unitOfWork.Save();

        }
        public void NewMessage(Message message)
        {
            //message.IsOrigin = message.OriginMessageId == null ? true : false;
            //message.IsOrigin = message.OriginMessageId == null;

            message.OriginalBody = StripHTML(message.Body);
            _unitOfWork.Entity.Insert(message);
            _unitOfWork.Save();
        }
        public void SendMessage(Message message, BaseUser user)
        {
            message.OriginMessageId ??= message.Id.ToString();
            message.Sent = true;
            message.SendingDateTime = DateTime.Now;
            message.Sender = user;
            if (message.DesignationId == 0)
                message.DesignationId = user.DesignationId;
            _unitOfWork.Entity.Update(message);
            _unitOfWork.Save();
        }
        public async Task<int> GetNewMessageCount(BaseUser user, List<string> ResponsibilityCodes)
        {
            if (user.JobCatId == 1)
            {
                return (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
                x => x.IsDeleted == false && x.IsReaded == false &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId) ||
                (x.Recipint.Id == user.Id && x.ResponsibilityCode == null)))
            , null, "Packages,Packages.Recipint")).GroupBy(item => item.OriginMessageId).Select(grp => grp.FirstOrDefault()).ToList().Count();
            }
            else
            {
                return (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
                x => x.IsDeleted == false && x.IsReaded == false &&
                (ResponsibilityCodes.Contains(x.ResponsibilityCode) ||
                (x.Recipint.Id == user.Id && x.ResponsibilityCode == null)))
            , null, "Packages,Packages.Recipint")).GroupBy(item => item.OriginMessageId).Select(grp => grp.FirstOrDefault()).ToList().Count();
            }

            //return (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(x => x.IsDeleted == false && x.IsReaded == false && x.Recipint.Id == UserId), x => x.OrderBy(u => u.CreatedOn), "Packages,Documents")).Count();

            //return (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true, x => x.OrderBy(u => u.CreatedOn), "Packages,Documents")).AsQueryable().SelectMany(p => p.Packages).Where(x => x.IsDeleted == false && x.IsReaded == false && x.Recipint.Id == UserId).Count();
        }
        public async Task<int> GetDraftMessageCount(BaseUser user)
        {
            if (user.JobCatId == 1)
            {
                return (await _unitOfWork.Entity.GetAllAsync(x => (x.CreatedById == user.Id || x.ResponsibilityCode == user.ResponsibilityCode) && x.Sent == false)).Count();
            }
            else
            {
                return (await _unitOfWork.Entity.GetAllAsync(x => x.CreatedById == user.Id && x.Sent == false)).Count();
            }
        }
        private static string StripHTML(string input)
        {
            if (input != null)
            {
                string result = Regex.Replace(input, "<[a-zA-Z/].*?>", String.Empty);
                result = Regex.Replace(result, "&nbsp;", String.Empty);
                return result;
            }
            else
            {
                return "";
            }
        }
        public async Task<IEnumerable<MessageDTO>> GetMessageHistory(string messageId, string CurrentUserId)
        {
            var messages = await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && (x.Id == Guid.Parse(messageId) || (x.OriginMessageId == messageId && x.Packages.Any(f => f.Recipint.Id == CurrentUserId)) || x.Sender.Id == CurrentUserId), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender,MessagesCategories");

            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }
        public async Task<IEnumerable<MessageDTO>> GetMessageMovements(string messageId)
        {
            return _mapper.Map<IEnumerable<MessageDTO>>(await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false && (x.Id == Guid.Parse(messageId) || (x.OriginMessageId == messageId)), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Sender,Documents,MessagesCategories,Packages.Recipint"));
        }
        public Message CloneTwoMessages(Message DisMessage, Message SourceMessage)
        {
            DisMessage.Packages = SourceMessage.Packages;
            //foreach (var doc in SourceMessage.Documents)
            //{
            //    doc.MessageId = DisMessage.Id;
            //    doc.Message = DisMessage;
            //    DisMessage.Documents.Add(doc);
            //}
            DisMessage.Body = SourceMessage.Body;
            DisMessage.OriginalBody = StripHTML(SourceMessage.Body);
            DisMessage.SenderDiscription = SourceMessage.SenderDiscription;
            DisMessage.SerialNumber = SourceMessage.SerialNumber;
            DisMessage.Title = SourceMessage.Title;
            DisMessage.MessagesCategories = SourceMessage.MessagesCategories;
            return DisMessage;
        }

        public Message CloneTwoDrafts(Message DisDraft, Message SourceDraft)
        {
            DisDraft.Body = SourceDraft.Body;
            DisDraft.OriginalBody = StripHTML(SourceDraft.Body);
            DisDraft.SenderDiscription = SourceDraft.SenderDiscription;
            DisDraft.Title = SourceDraft.Title;
            DisDraft.MessagesCategories = SourceDraft.MessagesCategories;
            return DisDraft;
        }

        public List<Message> OutsideOrgnizationMessages(string UserId)
        {
            return _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false &&
                (x.Sender.Id == UserId || x.Packages.Any(p => p.Recipint.Id == UserId && p.IsReaded == false)), x => x.OrderByDescending(u => u.CreatedOn), "Packages,Packages.Recipint,Documents,Sender").Result.ToList();
        }

        // =========== dashboard servises Interface  ==================================================

        public async Task<int> GetUnreplayOutboxMessagesCount(BaseUser user)
        {
            return (await _unitOfWork.Entity.GetAllAsync(x => (x.Sender.Id == user.Id
            || (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId)) && x.IsDeleted == false && x.Sent == true && x.Packages.Any(
            p => p.IsDeleted == false && p.IsReplyed == false && p.DaysToReplay > 0 && DateTime.Now > p.CreatedOn.AddDays(p.DaysToReplay))
        , null, "Packages,Packages.Recipint")).ToList().Count();

        }

        public async Task<int> GetUnreplayInboxMessagesCount(BaseUser user, List<string> ResponsibilityCodes)
        {

            return (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
            p => p.IsDeleted == false && p.IsReplyed == false && p.IsIgnore == false && p.DaysToReplay > 0 && DateTime.Now > p.CreatedOn.AddDays(p.DaysToReplay) &&
            (ResponsibilityCodes.Contains(p.ResponsibilityCode) ||
            (p.ResponsibilityCode == user.ResponsibilityCode && p.DesignationId == user.DesignationId) ||
            (p.Recipint.Id == user.Id && p.ResponsibilityCode == null)))
        , null, "Packages,Packages.Recipint")).ToList().Count();

        }

        public async Task<List<Message>> GetUnreplayOutboxMessagesPagingAsync(BaseUser user)
        {
            return ((await _unitOfWork.Entity.GetAllAsync(x => (x.Sender.Id == user.Id || (x.ResponsibilityCode == user.ResponsibilityCode && x.DesignationId == user.DesignationId)) && x.IsDeleted == false && x.Sent == true && x.Packages.Any(
            x => x.IsDeleted == false && x.IsReplyed == false && x.DaysToReplay > 0 && DateTime.Now > x.CreatedOn.AddDays(x.DaysToReplay))
        , null, "Packages,Packages.Recipint")).OrderByDescending(o => o.SendingDateTime)).ToList();

        }

        public async Task<List<Message>> GetUnreplayInboxMessagesPagingAsync(BaseUser user, List<string> ResponsibilityCodes)
        {
            var messages = await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.Packages.Any(
            p => p.IsDeleted == false && p.IsReplyed == false && p.IsIgnore == false && p.DaysToReplay > 0 && DateTime.Now > p.CreatedOn.AddDays(p.DaysToReplay) &&
            (ResponsibilityCodes.Contains(p.ResponsibilityCode) ||
            (p.ResponsibilityCode == user.ResponsibilityCode && p.DesignationId == user.DesignationId) ||
            (p.RecipintId == user.Id && p.ResponsibilityCode == null)))
        , null, "Packages,Packages.Recipint");
            return messages.ToList();

        }

        //============================================================================================

        public async Task<PagingList<Message>> GetInboxMessagesClassificationAsync(BaseUser user, string ResponsibilityCodes, int pageindex)
        {
            if (ResponsibilityCodes == null)
            {
                var messages = await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.IsDeleted == false && x.Packages.Any(
                p => p.IsDeleted == false && p.RecipintId == user.Id && p.ResponsibilityCode == null)
            , x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Documents,Sender,Packages.Recipint");
                return PagingList.Create(messages, 30, pageindex);
            }
            else
            {
                var messages = await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true && x.IsDeleted == false && x.Packages.Any(
                p => p.IsDeleted == false && p.ResponsibilityCode == ResponsibilityCodes)
            , x => x.OrderByDescending(u => u.SendingDateTime), "Packages,Documents,Sender,Packages.Recipint");
                return PagingList.Create(messages, 30, pageindex);
            }
        }

        public async Task<PagingList<Message>> GetOutboxMessagesClassificationAsync(BaseUser user, string ResponsibilityCodes, int pageindex)
        {
            if (ResponsibilityCodes == null)
            {
                return PagingList.Create((await _unitOfWork.Entity.GetAllAsync(x => x.Sender.Id == user.Id && x.ResponsibilityCode == null &&
                x.IsDeleted == false && x.Sent == true, null, "Packages,Documents,Sender")).OrderByDescending(o => o.SendingDateTime), 30, pageindex);
            }
            else
            {
                return PagingList.Create((await _unitOfWork.Entity.GetAllAsync(x => x.ResponsibilityCode == ResponsibilityCodes &&
               x.IsDeleted == false && x.Sent == true, null, "Packages,Documents,Sender")).OrderByDescending(o => o.SendingDateTime), 30, pageindex);
            }
        }

    }

}


//public async Task<IEnumerable<MessageDTO>> GetInboxMessages(string UserId)
//{
//    var messages = (await _unitOfWork.Entity.GetAllAsync(x => x.Sent == true, x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender")).AsQueryable().SelectMany(p => p.Packages).Where(x => x.IsDeleted == false && x.Recipint.Id == UserId).AsEnumerable().Select(r => r.Message);
//    return _mapper.Map<IEnumerable<MessageDTO>>(messages);
//}
//public async Task<IEnumerable<MessageDTO>> GetOutboxMessages(string UserId)
//{
//    return _mapper.Map<IEnumerable<MessageDTO>>(await _unitOfWork.Entity.GetAllAsync((x => x.Sender.Id == UserId && x.IsDeleted == false && x.Sent == true), t => t.OrderByDescending(r => r.CreatedOn), "Packages,Documents,Sender"));
//}
//public async Task<IEnumerable<MessageDTO>> GetDraftMessages(string UserId)
//{
//    var messages = await _unitOfWork.Entity.GetAllAsync((x => x.CreatedById == UserId && x.Sent == false), t => t.OrderByDescending(r => r.CreatedOn), "Packages,Documents,Sender");
//    return _mapper.Map<IEnumerable<MessageDTO>>(messages);
//}
//public async Task<IEnumerable<MessageDTO>> GetDeletedMessages(string UserId)
//{
//    var messages = (await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == true, x => x.OrderByDescending(u => u.CreatedOn), "Packages,Documents,Sender")).AsQueryable().SelectMany(p => p.Packages).Where(x => x.IsDeleted == true && x.Recipint.Id == UserId).AsEnumerable().Select(r => r.Message);

//  return PagingList.Create(messages, 30, pageindex);
//  }

