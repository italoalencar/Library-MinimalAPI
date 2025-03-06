using AutoMapper;
using Library_MinimalAPI.DAL;
using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Models;

namespace Library_MinimalAPI.Services;

public class BookService
{
    private readonly DAL<Book> dal;
    private readonly IMapper _mapper;

    public BookService(DAL<Book> dal, IMapper mapper)
    {
        this.dal = dal;
        _mapper = mapper;
    }

    public ReadBookDTO Create(CreateBookDTO bookDTO)
    {
        var book = _mapper.Map<Book>(bookDTO);
        var bookCreated = dal.Create(book);
        return _mapper.Map<ReadBookDTO>(bookCreated);
    }

    public ICollection<ReadBookDTO> GetAll()
    {
        return _mapper.Map<List<ReadBookDTO>>(dal.Read());
    } 
    
    public ReadBookDTO? GetById(int id)
    {
        var book = dal.ReadBy(b => b.Id == id);
        return _mapper.Map<ReadBookDTO>(book);
    }

    public bool Update(UpdateBookDTO bookDTO)
    {
        var book = _mapper.Map<Book>(bookDTO);
        return dal.Update(book, b => b.Id == book.Id);
    }

    public bool Delete(int id)
    {
        return dal.Delete(book => book.Id == id);
    }
}
