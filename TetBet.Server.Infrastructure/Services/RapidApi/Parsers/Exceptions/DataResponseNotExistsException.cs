using System;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Parsers.Exceptions
{
    public class DataResponseNotExistsException : Exception
    {
        public DataResponseNotExistsException(string message) : base(message)
            => Console.WriteLine(message);
    }
}