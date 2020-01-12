using System.Collections.Generic;
using Clean.Core.Domain;
using MediatR;

namespace Clean.Functionality.Services
{
    public class RetrieveAllServicesRequest : IRequest <List<Service>>{}
}