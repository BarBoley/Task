

namespace Task.Services.Cache
{
	internal interface ICacheService<T>
	{
		public void Clear();

		public void TryAddCache(string request, T obj);
		public bool ContainCache(string request);

		public bool TryGetCache<T>(string request, out T? cacheObject);
	}
}
