using ACS.Core.Entities;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ACS.Services
{
    public class CategoryServices<T> : ICategoryServices<T> where T : Category
    {
        private readonly IUnitOfWork<Category> _unitOfWork;
        public CategoryServices
            (
            IUnitOfWork<Category> unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            return (await _unitOfWork.Entity.GetAllAsync(x => x.IsDeleted == false, x => x.OrderByDescending(u => u.Id))).ToList();
        }
    }
}
