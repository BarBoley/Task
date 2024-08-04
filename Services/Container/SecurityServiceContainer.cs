using Task.Security;
using Task.Services.Cache;
using Task.Services.Factories;

namespace Task.Services.Container
{
    internal class SecurityServiceContainer : IServiceContainer
	{
		public void LoadContainer(ServiceLocator serviceLocator)
		{
			ClientFactory clientFactory = new ClientFactory("https://apilist.tronscanapi.com/api/security/");
			CacheService cacheService = new CacheService(15);
			SecurityService securityService = new SecurityService(clientFactory.GetNewObject(), cacheService);
			serviceLocator.TryAddService(clientFactory);
			serviceLocator.TryAddService(cacheService);
			serviceLocator.TryAddService(securityService);
		}
	}
}
