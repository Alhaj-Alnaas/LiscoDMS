using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Providers
{
    public interface IUserProvider
    {
        Task<List<string>> GetUserRolesAsync(BaseUser user);
        Task<BaseUser> GetCurrentUserAsync();
        string GetCurrentUserId();
        List<BaseUser> GetAllUsers(BaseUser CurrentUser);
        List<BaseUser> GetRelatedUsers(int designationId, string CurrRespCode);
        BaseUser GetUserById(string Id);
        BaseUser GetUserByFileNumber(string FileNumber);
        BaseUser GetUserBySubUserFileNumber(string FileNumber);
        List<BaseUser> GetAllLeaders(BaseUser CurrentUser);
        List<BaseUser> GetLowLevelUsers(int designationId, string CurrRespCode);
        BaseUser GetUserByResponsibilityCode(string ResponsibilityCode, int designationId);
    }
}
