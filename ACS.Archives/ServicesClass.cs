using ACS.Core.Entities;
using ACS.Core.Entities.Bases;
using ACS.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACS.Archives
{
   public class ServicesClass 
    {
        
        public BaseUser GetUserByFileNumber(string FileNumber, DataContext _dataContext)
        {
            return _dataContext.Users.Where(x => x is ApplicationUser && x.FileNumber == FileNumber).FirstOrDefault();
        }

    }
}
