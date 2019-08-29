using System;

namespace Caracan.Pdf.Exceptions
{
    public class CaracanBaseException : Exception
    {
        protected CaracanBaseException(string message) : base(message)
        {
        }

        protected CaracanBaseException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}