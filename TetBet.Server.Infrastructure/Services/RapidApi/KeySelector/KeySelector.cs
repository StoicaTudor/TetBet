using System.Linq;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Server.Infrastructure.Services.RapidApi.KeySelector
{
    public class KeySelector : IKeySelector
    {
        private readonly IUnitOfWork _unitOfWork;

        public KeySelector(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetKeyWithMostAvailableCalls()
        {
            return _unitOfWork
                .RapidApiKey
                .Get()
                .OrderByDescending(key => key.RemainingCalls)
                .First()
                .Key;
        }
    }
}