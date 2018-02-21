using System;

namespace CsprojScan.Contracts
{
    /// <summary>
    /// Simple exception handler interface
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Handles an exception
        /// </summary>
        /// <param name="e">the exception to be handled</param>
        void HandleException(Exception e);
    }
}
