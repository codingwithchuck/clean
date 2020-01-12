using System;
using System.Collections.Generic;
using Bogus;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;

namespace Clean.Infrastructure.DataAccess
{
    public class InMemoryData
    {
        public List<User> Users { get; set; }
        
        public List<Service> Services { get; set; }

        /// <summary>
        /// Randomly generates 500 users and 100 Services. 
        /// </summary>
        /// <returns></returns>
        public InMemoryData BuildData()
        {
            GenerateRandomUsers();
            GenerateRandomServices();

            RandomlyAssociateUsersWithServices();

            return this;
        }
        
        private void RandomlyAssociateUsersWithServices()
        {
            var servicesMaxIndex = this.Services.Count - 1;

            foreach (var user in Users)
            {
                var numberOfServicesForUser = new Random().Next(0, 5);

                for (var index = 0; index < numberOfServicesForUser; index++)
                {
                    var servicePosition = new Random().Next(0, servicesMaxIndex);

                    var service = Services[servicePosition];
                    user.Subscriptions.Add(service);
                }
            }
        }

        private void GenerateRandomServices()
        {
            Services = new Faker<Service>()
                .RuleFor(s => s.Id, (f, s) => f.IndexGlobal)
                .RuleFor(s => s.Name, (f, s) => f.Name.JobArea())
                .RuleFor(s => s.Price, (f, s) => decimal.Parse(f.Commerce.Price()))
                .RuleFor(u => u.CreatedDateTime, (f, s) => f.Date.Recent())
                .RuleFor(u => u.LastModifiedDateTime, (f, s) => f.Date.Recent())
                .Generate(100);
        }

        private void GenerateRandomUsers()
        {
            Users = new Faker<User>()
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                .RuleFor(u => u.Password, (f, u) => f.Random.String2(8))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
                .RuleFor(u => u.Title, (f, u) => f.Name.JobTitle())
                .RuleFor(u => u.Id, (f, u) => f.IndexGlobal)
                .RuleFor(u => u.AccountStatus,
                    (f, u) => f.Random.Enum<AccountStatus>())
                .RuleFor(u => u.BirthDate, (f, u) => f.Person.DateOfBirth)
                .RuleFor(u => u.SocialSecurityNumber,
                    (f, u) => new SocialSecurityNumber(f.Random.Int(100000000, 999999999).ToString()))
                .RuleFor(u => u.CreatedDateTime, (f, u) => f.Date.Recent())
                .RuleFor(u => u.LastModifiedDateTime, (f, u) => f.Date.Recent())
                .Generate(500);
        }
    }
}