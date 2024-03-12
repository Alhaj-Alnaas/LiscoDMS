using ACS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
    public interface IExtendedUserInfoServices<T> where T : class
    {
        Task<ExtendedUserInfo> GetExtendedUserInfo(string fileNumber, string APIpath);
    }
}
