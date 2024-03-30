using AutoMapper;
using DapperGenericRepository.Model.Dtos.User;

namespace DapperGenericRepository.Model.Dtos.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<Entities.User, UserRequestModel>().ReverseMap();
        }
    }
}