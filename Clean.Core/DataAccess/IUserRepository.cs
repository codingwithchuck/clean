using System.Collections.Generic;
using Clean.Common.Data.Specifications;
using Clean.Core.Domain;

namespace Clean.Core.DataAccess
{
    public interface IUserRepository
    {
        IList<User> GetAll();

        User Get(int userId);

        User Add(User user);

        User Update(User user);

        void Delete(int userId);

        IList<User> Filter(IDataSpecification<User> specification);
    }
}