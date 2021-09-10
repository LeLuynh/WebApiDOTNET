using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoUtilities.Exceptions
{
    public class EProductException : Exception
    {
        public EProductException()
        {
        }

        public EProductException(string message)
            : base(message)
        {
        }

        public EProductException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
