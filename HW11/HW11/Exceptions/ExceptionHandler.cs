using System;
using Microsoft.Extensions.Logging;

namespace HW11.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public void HandleException<T>(T exception) where T : Exception
        {
            this.Handle((dynamic) exception);
        }

        public void Handle(InvalidNumberException exception)
        {
            _logger.LogError($"Invalid number: {exception.Message}");
        }

        public void Handle(InvalidSyntaxException exception)
        {
            _logger.LogError($"Invalid syntax: {exception.Message}");
        }

        public void Handle(InvalidCharacterException exception)
        {
            _logger.LogError($"Invalid calculator symbol: {exception.Message}");
        }
    }
}