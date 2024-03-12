using ACS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Interfaces.Services
{
    public interface IFeedbackServices<T> where T : class
    {
        void SendFeedback(string note, ApplicationUser user);
    }
}
