using CsprojScan.Contracts;
using System;

namespace CsprojScan.Implementation.Exception
{
    /// <summary>
    /// Default implementation of the exception handler
    /// </summary>
    public class ExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Prints the exception message to stdout
        /// </summary>
        /// <param name="e">the exception to be handled</param>
        public void HandleException(System.Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
