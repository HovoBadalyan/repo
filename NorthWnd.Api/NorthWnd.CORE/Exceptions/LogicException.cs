using System;

namespace NorthWnd.CORE.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException(string message)
            : base(message)
        {

        }
    }
}
