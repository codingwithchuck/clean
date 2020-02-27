using System.Collections.Generic;
using Clean.Core.Domain;
using MediatR;

namespace Clean.FeatureSets.Users.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<List<User>>
    {
        
    }
}