using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exceptions
{
    public class GroupException : Exception
    {
        public GroupException()
        {

        }

        public GroupException(string message) : base(message)
        {

        }

    }
}