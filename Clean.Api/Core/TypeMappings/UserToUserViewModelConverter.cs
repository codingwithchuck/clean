using AutoMapper;
using Clean.Api.ViewModels;
using Clean.Core.Domain;

namespace Clean.Api.Core.TypeMappings
{
    public class UserToUserViewModelConverter : ITypeConverter<User, UserViewModel>
    {
        public UserViewModel Convert(User source, UserViewModel destination, ResolutionContext context)
            => new UserViewModel
                {
                    Id = source.Id,
                    Email = source.Email,
                    Title = source.Title,
                    AccountStatus = (int) source.AccountStatus,
                    AccountStatusDisplay = source.AccountStatus.ToString(),
                    BirthDate = source.BirthDate?.ToString() ?? string.Empty,
                    FirstName = source.FirstName,
                    LastName = source.LastName,
                    Suffix = source.Suffix,
                    SocialSecurityNumber = source.SocialSecurityNumber.ToString()
                };
    }
}