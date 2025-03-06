using AutoMapper;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDTO, Book>();
        CreateMap<Book, ReadBookDTO>().ReverseMap();
    }
}
