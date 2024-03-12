using ACS.Core.Entities;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Services
{
    public class ExtendedUserInfoServices<T> : IExtendedUserInfoServices<T> where T : ExtendedUserInfo
    {
        //private readonly IUnitOfWork<ExtendedUserInfo> _unitOfWork;
        //public ExtendedUserInfoServices(
        //    IUnitOfWork<ExtendedUserInfo> unitOfWork
        //    )
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public async Task<ExtendedUserInfo> GetExtendedUserInfo(string fileNumber, string APIpath)
        {
            ExtendedUserInfo extendedUserInfo;
            using (var client = new HttpClient())
            {
                var url = new Uri(APIpath + fileNumber);
                var response = await client.GetAsync(url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                extendedUserInfo = JsonConvert.DeserializeObject<ExtendedUserInfo>(json);
            }
            return extendedUserInfo;
        }
    }
}
