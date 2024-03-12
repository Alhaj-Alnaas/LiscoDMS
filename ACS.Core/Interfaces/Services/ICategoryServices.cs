using ACS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACS.Core.Interfaces.Services
{
    public interface ICategoryServices<T> where T : class
    {
        Task<IList<Category>> GetAllCategories();
    }
}
