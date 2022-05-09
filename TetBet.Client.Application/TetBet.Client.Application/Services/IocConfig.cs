using Unity;

namespace TetBet.Client.Application.Services
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