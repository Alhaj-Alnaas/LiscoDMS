using ACS.Core.Entities;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
//using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Services
{
    public class OrgnaizationServices<T>: IOrgnaizationServices<T> where T: Organization
    {
        private readonly IUnitOfWork<Organization> _unitOfWork;
       // private readonly IHostingEnvironment _hosting;

        public OrgnaizationServices(
            IUnitOfWork<Organization> unitOfWork
            //, IHostingEnvironment hosting
            )
        {
            _unitOfWork = unitOfWork;
          // _hosting = hosting;
        }
        public async Task<Organization> GetOrgnaizationById(string Id)
        {
            return await _unitOfWork.Entity.FindAsync(m => m.Id.ToString() == Id && m.IsDeleted == false && DateTime.Now <= m.EndDate);
        }

        public async Task<IEnumerable<Organization>> GetAllOrgnaizations()
        {
            return await _unitOfWork.Entity.GetAllAsync(m => DateTime.Now <= m.EndDate && m.IsDeleted == false );
        }

        public async Task<IEnumerable<Organization>> GetOrgnaizationsByFileNumber(string FileNumber)
        {
            return await _unitOfWork.Entity.GetAllAsync(m => m.DelegateNo == FileNumber && DateTime.Now <= m.EndDate && m.IsDeleted == false);
        }

        public async Task<Organization> GetOrgnaizationByResponsibilityCode(string ResponsibilityCode, int DesignationId)
        {
            return await _unitOfWork.Entity.FindAsync(m => m.ResponsibilityCode == ResponsibilityCode && DateTime.Now <= m.EndDate  );
        }
    }
}
