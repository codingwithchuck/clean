using System.Collections.Generic;
using Clean.Common.Data.Specifications;
using Clean.Common.Specifications;
using Clean.Core.Domain;

namespace Clean.Core.DataAccess
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User Get(int userId);

        User Add(User user);

        User Update(User user);

        void Delete(int userId);

        List<User> Filter(IDataSpecification<User> specification);
    }
}