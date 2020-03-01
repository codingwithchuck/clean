using System.Collections.Generic;
using System.Linq;
using Clean.Common.Data.Specifications;
using Clean.Common.Specifications;
using Clean.Core.DataAccess;
using Clean.Core.Domain;

namespace Clean.Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly InMemoryData _data;

        public UserRepository(InMemoryData data) 
            => _data = data;

        /// <summary>
        /// Retrieves all the users from the data source.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
            => _data.Users;

        /// <summary>
        /// Get user by it's Id. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>If the user is not found, a user with an id of -1 is returned.</returns>
        public User Get(int userId)
        {
            var user = _data.Users.SingleOrDefault(s => s.Id == userId);
            return user ?? User.Empty;
        }

        /// <summary>
        /// Add User to the data source
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Add(User user)
        {
            SetUserId(user);

            _data.Users.Add(user);
            return user;
        }

        private void SetUserId(User user)
        {
            var first = _data.Users.OrderByDescending(s => s.Id).First();
            user.Id = first.Id + 1;
        }

        /// <summary>
        /// Updates the user in the data source
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Update(User user)
        {
            RemoveItem(user.Id);

            _data.Users.Add(user);

            return user;
        }

        private void RemoveItem(int userId)
        {
            const int notFoundPosition = -1;
            var index = _data.Users.FindIndex(s => s.Id == userId);

            if (index > notFoundPosition)
            {
                _data.Users.RemoveAt(index);
            }
        }

        /// <summary>
        /// Delete user from data source
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int userId)
            => RemoveItem(userId);

        /// <summary>
        /// Filters by a User Specification
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        public List<User> Filter(IDataSpecification<User> specification)
        {
            var queryable = _data.Users.AsQueryable();
            return DataSpecificationProcessor<User>
                .BuildQuery(queryable, specification)
                .ToList();
        }
    }
}