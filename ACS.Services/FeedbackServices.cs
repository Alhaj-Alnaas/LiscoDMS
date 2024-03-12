using ACS.Core.Entities;
using ACS.Core.Interfaces.Services;
using ACS.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Services
{
    public class FeedbackServices<T> : IFeedbackServices<T> where T : Feedback
    {
        private readonly IUnitOfWork<Feedback> _unitOfWork;
        public FeedbackServices(IUnitOfWork<Feedback> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void SendFeedback(string note, ApplicationUser user)
        {
            var feedback = new Feedback
            {
                User = user,
                Note = note,
                ResponsibilityCode = user.ResponsibilityCode
            };
            _unitOfWork.Entity.Insert(feedback);
            _unitOfWork.Save();
        }
    }
}
