using AutoMapper;
using LibraryManager.Models.Domains;
using LibraryManager.Models.ViewModels.User;

namespace LibraryManager.Models.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUser, User>()
                .ForMember(user => user.FirstName, config => config.MapFrom(create => create.FirstName))
                .ForMember(user => user.LastName, config => config.MapFrom(create => create.LastName))
                .ForMember(user => user.UserName, config => config.MapFrom(create => create.UserName));

            CreateMap<User, DetailsUser>()
                .ForMember(details => details.Id, config => config.MapFrom(user => user.Id))
                .ForMember(details => details.FirstName, config => config.MapFrom(user => user.FirstName))
                .ForMember(details => details.LastName, config => config.MapFrom(user => user.LastName))
                .ForMember(details => details.UserName, config => config.MapFrom(user => user.UserName))
                .ForMember(details => details.Confirm, config => config.MapFrom(user => user.EmailConfirmed));
        }
    }
}
