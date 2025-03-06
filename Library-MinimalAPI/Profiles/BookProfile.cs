using AutoMapper;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDTO, Book>();
        CreateMap<Book, ReadBookDTO>()
            .ForMember(bookDTO => bookDTO.Author, options => 
            options.MapFrom(book => book.Author));
        CreateMap<UpdateBookDTO, Book>();
    }
}
