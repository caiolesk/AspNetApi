using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiGuaxCore.customException
{
    public class UserConflictException : Exception
    {
        public UserConflictException(string message) : base(message) { }
    }
}
