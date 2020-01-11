using System;
using System.Collections.Generic;
using Clean.Core.ValueTypes;

namespace Clean.Core.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? Title { get; set; }

        public DateTime? BirthDate { get; set; }

        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;

        public IList<Service> Subscriptions { get; set; } = new List<Service>();

        public SocialSecurityNumber SocialSecurityNumber { get; set; } = new SocialSecurityNumber();

        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedDateTime { get; set; }

        public static readonly User Empty = new User {Id = -1};
    }
}
        