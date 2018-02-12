using System;

namespace CsprojScan.Contracts
{
    public interface IExceptionHandler
    {
        void HandleException(Exception e);
    }
}
