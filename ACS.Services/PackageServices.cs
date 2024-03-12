using ACS.Core.Entities;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using ACS.Core.DTOs;
using System.Linq;
using AutoMapper;

namespace ACS.Services
{
    public class PackageServices<T> : IPackageServices<T> where T : class
    {
        private readonly IUnitOfWork<Package> _unitOfWork;
        protected readonly IUserProvider _userProvider;
        private readonly IMapper _mapper;

        public PackageServices(
            IUnitOfWork<Package> unitOfWork
            , IUserProvider userProvider
            , IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
            _mapper = mapper;
        }

        public void MarkMessageAsReadedOrUnreaded(Package package, bool IsReaded = true)
        {
            package.IsReaded = IsReaded;
            _unitOfWork.Entity.Update(package);
            _unitOfWork.Save();

            //var package = await _unitOfWork.Entity.FindAsync(p => p.Id == Guid.Parse(packageId));
            //package.IsReaded = IsReaded;
            //_unitOfWork.Entity.Update(package);
            //_unitOfWork.Save();
        }

        public async Task DeleteMessagesFromInboxAsync(List<string> packagesIds)
        {
            foreach (var packageId in packagesIds)
            {
                var package = await _unitOfWork.Entity.FindAsync(p => p.Id == Guid.Parse(packageId));
                _unitOfWork.Entity.Delete(package);
                _unitOfWork.Save();
            }
        }

        //public void MarkMessageAsReplied(Package package)
        //{
        //    package.IsReplyed = true;
        //    _unitOfWork.Entity.Update(package);
        //    _unitOfWork.Save();

        //}

        //public async Task<List<Package>> GetPackgesRelitedMessage(string OrgMsgId)
        //{
        //    return (await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false, x => x.OrderByDescending(u => u.CreatedOn), "Packages")).AsQueryable().Where((m => m.Message.OriginMessageId == OrgMsgId || m.Message.Id.ToString() == OrgMsgId)).ToList();
        //}

        //public void SavePackgesRelitedMessage(List<Package> packages, Guid MessageId)
        //{
        //    foreach (var package in packages)
        //    {
        //        package.MessageId = MessageId;
        //        _unitOfWork.Entity.Insert(package);
        //        _unitOfWork.Save();
        //    }
        //}
        public void MarkMessageAsIgnored(Package package, bool IsIgnored = true)
        {
            package.IsIgnore = IsIgnored;
            _unitOfWork.Entity.Update(package);
            _unitOfWork.Save();

        }

        public async Task<Package> GetPackegeById(Guid Id)
        {
            return await _unitOfWork.Entity.FindAsync(p => p.Id == Id);
        }

    }
}
