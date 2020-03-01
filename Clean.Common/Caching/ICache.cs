using System;
using System.Threading.Tasks;

namespace Clean.Common.Caching
{
    public interface ICache
    {
        /// <summary>
        /// Add an item to cache providing a unique key for retrieval and a relative time to now for expiration.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="items"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        TItem Add<TItem>(string key, TItem items, TimeSpan expirationRelativeToNow);

        /// <summary>
        /// Add an item to cache providing a unique key for retrieval and an absolute time for expiration.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="items"></param>
        /// <param name="absoluteExpiration"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        TItem Add<TItem>(string key, TItem items, DateTimeOffset absoluteExpiration);

        /// <summary>
        /// Retrieves item by key. If it's not found a null is returned.
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        TItem Get<TItem>(string key);

        /// <summary>
        /// Retrieves items by key, if it's not found a null is returned. Async/await
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        Task<TItem> GetAsync<TItem>(string key);

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is asynchronously loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        Task<TItem> GetOrLoadAsync<TItem>(string key, TimeSpan expirationRelativeToNow, Func<Task<TItem>> load);

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is asynchronously loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        Task<TItem> GetOrLoadAsync<TItem>(string key, DateTimeOffset absoluteExpiration, Func<Task<TItem>> load);

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        TItem GetOrLoad<TItem>(string key, TimeSpan expirationRelativeToNow, Func<TItem> load);

        /// <summary>
        /// Retrieves item by key, if the item is not found, the items is loaded.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="expirationRelativeToNow"></param>
        /// <param name="load"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        TItem GetOrLoad<TItem>(string key, DateTimeOffset absoluteExpiration, Func<TItem> load);

        /// <summary>
        /// Removes the item from the cache
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="TItem"></typeparam>
        void Remove<TItem>(string key);
    }
}