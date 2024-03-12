using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
   public interface IContactServices<T> where T : class
    {
        void AddContact(Contact contact);
        Task<int> GetContactCount(string UserId);
        Task<IEnumerable<Contact>> GetContactByUser(string UserId);
        Task<IEnumerable<Contact>> Search(string SearchText, string UserId);
        void DeleteContact(Contact contact);
    }
}
