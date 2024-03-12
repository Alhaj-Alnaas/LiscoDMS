using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ACS.Services
{
    public class ContactServices<T> : IContactServices<T> where T : Contact
    {
        private readonly IUnitOfWork<Contact> _unitOfWork;
        public ContactServices(
            IUnitOfWork<Contact> unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public void AddContact(Contact contact)
        {
            _unitOfWork.Entity.Insert(contact);
            _unitOfWork.Save();
        }
        public async Task<int> GetContactCount(string UserId)
        {
            return (await _unitOfWork.Entity.GetAllAsync(x => x.UserID == UserId)).Count();
        }
        public async Task<IEnumerable<Contact>> GetContactByUser(string UserId)
        {
            return (await _unitOfWork.Entity.GetAllAsync((x => x.UserID == UserId)));
        }
        public void DeleteContact(Contact contact)
        {
            _unitOfWork.Entity.PermanentDelete(contact);
            _unitOfWork.Save();
        }
        public async Task<IEnumerable<Contact>> Search(string SearchText, string UserId)
        {
            return (await _unitOfWork.Entity.GetAllAsync(x => x.UserID == UserId
            && x.User.FullName.Contains(SearchText), x => x.OrderBy(u => u.CreatedOn)));
        }
    }
}
