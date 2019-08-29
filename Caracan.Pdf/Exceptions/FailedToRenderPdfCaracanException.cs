using System;

namespace Caracan.Pdf.Exceptions
{
    public class FailedToRenderPdfCaracanException : CaracanBaseException
    {
        public string FileName { get; set; }


        public FailedToRenderPdfCaracanException(string message, string fileName) : base(message)
        {
            FileName = fileName;
        }
        
        public FailedToRenderPdfCaracanException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}