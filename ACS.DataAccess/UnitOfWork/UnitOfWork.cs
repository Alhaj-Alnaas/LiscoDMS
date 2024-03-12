using ACS.Core.Entities.Bases;
using ACS.Core.Interfaces.Providers;
using ACS.Core.Interfaces.Repositories;
using ACS.Core.Interfaces.UnitOfWork;
using ACS.DataAccess.Repositories;
using System.Threading.Tasks;

namespace ACS.DataAccess.UintOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private IGenericRepository<T> _entity;
        protected readonly IUserProvider _userProvider;
        public UnitOfWork(
            DataContext context,
            IUserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
        } 
        public IGenericRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(_context, _userProvider));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
