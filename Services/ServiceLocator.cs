
namespace Task.Services
{
	internal class ServiceLocator
	{
		public ServiceLocator() { }
		private readonly Dictionary<string, IService> services = new ();
		public static ServiceLocator Instance { get; private set; }
		public static void Initialize()
		{
			Instance = new ServiceLocator();
		}

		public bool TryGetService<T>(out T? service) where T : IService
		{
			string key = typeof(T).Name;
			service = default;
			if (services.ContainsKey(key))
			{
				service = (T)services[key];
				return true;
			}
			return false;

		}

		public bool TryAddService<T>(T service) where T : IService
		{
			string key = typeof(T).Name;
			return services.TryAdd(key, service);
		}

		public bool TryRemoveService<T>() where T : IService
		{
			string key = typeof(T).Name;
			if(services.ContainsKey(key))
			{
				services.Remove(key);
				return true;
			}
			return false;
		}
	}
}
