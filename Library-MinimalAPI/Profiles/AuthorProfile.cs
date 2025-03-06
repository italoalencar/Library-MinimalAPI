using AutoMapper;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorDTO, Author>();
        CreateMap<Author, ReadAuthorDTO>().ReverseMap();
    }
}
