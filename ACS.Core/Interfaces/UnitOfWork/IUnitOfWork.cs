using ACS.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository <T> Entity { get; }
        void Save();
    }
}
