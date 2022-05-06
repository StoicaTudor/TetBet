using Unity;

namespace TetBet.Core.Services
{
    public class IocConfig
    {
        private readonly IUnityContainer _unityContainer;

        public IocConfig(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
    }
}