using CsprojScan.Contracts;
using System;

namespace CsprojScan.Implementation
{
    public class ExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception e)
        {
            Console.WriteLine($"{e.Message}:{e.StackTrace}");
        }
    }
}
