using System;
using System.Collections.Generic;
using Clean.Core.Domain;
using Clean.Core.ValueTypes;

namespace Clean.Api.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string Title { get; set; } = string.Empty;

        public string BirthDate { get; set; } = string.Empty;

        public int AccountStatus { get; set; }
        
        public string AccountStatusDisplay { get; set; }
        
        public IList<Service> Subscriptions { get; set; } = new List<Service>();

        public string SocialSecurityNumber { get; set; }
    }
}