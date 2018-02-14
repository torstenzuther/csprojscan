using CsprojScan.Contracts;
using System;

namespace CsprojScan.Implementation.Exception
{
    public class ExceptionHandler : IExceptionHandler
    {
        public void HandleException(System.Exception e)
        {
            Console.WriteLine($"{e.Message}:{e.StackTrace}");
        }
    }
}
