

namespace Task.Services.Cache
{
    internal class CacheService : ICacheService<object>, IService
    {
        private Dictionary<string, object> _cache = new();
        private int _maxCacheVolume;

        public CacheService(int maxCacheVolume)
        {
            _maxCacheVolume = maxCacheVolume;
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public bool ContainCache(string key)
        {
            return _cache.ContainsKey(key);
        }

        public void TryAddCache(string request, object obj)
        {
            if (_cache.ContainsKey(request))
            {
                _cache[request] = obj;
            }
            else if (_cache.Count < _maxCacheVolume)
                _cache.Add(request, obj);
            else
            {
                _cache.Clear();
                _cache.Add(request, obj);
            }
        }

        public bool TryGetCache<T>(string request, out T? cacheObject)
        {
            cacheObject = default;

            if (_cache.TryGetValue(request, out object obj))
            {
                cacheObject = (T)obj;
                return true;
            }

            return false;
        }
    }
}
