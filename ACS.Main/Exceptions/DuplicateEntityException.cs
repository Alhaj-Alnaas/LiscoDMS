using System;

namespace ACS.Web.Exceptions
{
    public class DuplicateEntityException : Exception
    {
        public DuplicateEntityException()
        {
        }

        public DuplicateEntityException(string message) : base(message)
        {
        }
    }
}
