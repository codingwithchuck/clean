using System.Collections.Generic;
using Clean.Core.Domain;

namespace Clean.Api.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;

        public string? Title { get; set; }

        public string BirthDate { get; set; } = string.Empty;

        public string SocialSecurityNumber { get; set; } = string.Empty;

        public int AccountStatus { get; set; }

        public string AccountStatusDisplay { get; set; } = string.Empty;
        
        public IList<Service> Subscriptions { get; set; } = new List<Service>();

    }
}