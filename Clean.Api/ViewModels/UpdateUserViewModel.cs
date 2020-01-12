namespace Clean.Api.ViewModels
{
    public class AddUserViewModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string BirthDate { get; set; } = string.Empty;

        public string SocialSecurityNumber { get; set; } = string.Empty;
    }

    public class UpdateUserViewModel : AddUserViewModel
    {
        public int Id { get; set; }
    }
}