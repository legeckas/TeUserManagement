using System;
using System.Net;

namespace TeUserManagement.Domain.Helpers.Exceptions
{
    public class NotFoundException : Exception, ICustomException
    {
        public NotFoundException(string? message = null) 
            : base(message)
        { }

        public int StatusCode => (int)HttpStatusCode.NotFound;
    }
}
