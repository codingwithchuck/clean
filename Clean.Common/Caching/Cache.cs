using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Clean.Common.Caching
{
    public class Cache : ICache
    {
        private readonly IMemoryCache _cache;

        public Cache(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        /// <summary>
        /// Add an item to cache providing a unique key for retrieval and a relative time to now for expiration.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="items"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public TItem Add<TItem>(string key, TItem items, TimeSpan expirationRelativeToNow)
        {
            return _cache.Set(key, items, expirationRelativeToNow);
        }

        /// <summary>
        /// Add an item to cache providing a unique key for retrieval and an absolute time for expiration.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="items"></param>
        /// <param name="absoluteExpiration"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public TItem Add<TItem>(string key, TItem items, DateTimeOffset absoluteExpiration)
        {
            return _cache.Set(key, items, absoluteExpiration);
        }

        /// <summary>
        /// Retrieves item by key. If it's not found a null is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public TItem Get<TItem>(string key)
        {
            return _cache.Get<TItem>(key);
        }

        /// <summary>
        /// Retrieves items by key, if it's not found a null is returned. Async/await
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public Task<TItem> GetAsync<TItem>(string key)
        {
            var item = _cache.Get<TItem>(key);
            return Task.FromResult(item);
        }

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is asynchronously loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public async Task<TItem> GetOrLoadAsync<TItem>(string key, TimeSpan expirationRelativeToNow, Func<Task<TItem>> load)
        {
            var item = _cache.Get<TItem>(key);

            if (item != null)
            {
                item = await load();
                _cache.Set(key, item, expirationRelativeToNow);
            }

            return item;
        }

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is asynchronously loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public async Task<TItem> GetOrLoadAsync<TItem>(string key, DateTimeOffset absoluteExpiration, Func<Task<TItem>> load)
        {
            var item = _cache.Get<TItem>(key);

            if (item != null)
            {
                item = await load();
                _cache.Set(key, item, absoluteExpiration);
            }

            return item;
        }

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public TItem GetOrLoad<TItem>(string key, TimeSpan expirationRelativeToNow, Func<TItem> load)
        {
            var item = _cache.Get<TItem>(key);

            if (item != null)
            {
                item = load();
                _cache.Set(key, item, expirationRelativeToNow);
            }

            return item;
        }

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public TItem GetOrLoad<TItem>(string key, DateTimeOffset absoluteExpiration, Func<TItem> load)
        {
            var item = _cache.Get<TItem>(key);

            if (item != null)
            {
                item = load();
                _cache.Set(key, item, absoluteExpiration);
            }

            return item;
        }

        /// <summary>
        /// Removes the item from the cache
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        public void Remove<TItem>(string key)
        {
            _cache.Remove(key);
        }
    }
}