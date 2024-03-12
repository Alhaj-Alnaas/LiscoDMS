using ACS.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
    public interface IOrgnaizationServices<T> where T : class
    {
        Task<IEnumerable<Organization>> GetAllOrgnaizations();
        Task<IEnumerable<Organization>> GetOrgnaizationsByFileNumber(string FileNumber);
        Task<Organization> GetOrgnaizationByResponsibilityCode(string ResponsibilityCode, int DesignationId);
        Task<Organization> GetOrgnaizationById(string Id);
    }
}
